I'll start by looking at what the library actually contains so the advice fits your code.

I read through the C# sources (`ComputerNetworking.cs`, `DateTime.cs`, `EmailAddress.cs`, `IDs.cs`), the TypeScript `Source/` tree, and the C++ scaffold in `CPP/Core/`. Here is my advice, specific to this library.
---

## 0. What kind of C++ library this is

The whole library is constants: numbers, strings, enum-like groups and one regex. There's nothing to compile into a `.lib`/`.a`, so in C++ it should be a **header-only library**.

So the Visual Studio scaffold you generated (`Core.vcxproj` as a *StaticLibrary*, `pch.h`, `framework.h`, `Core.cpp`) doesn't fit:
- `framework.h` defines `WIN32_LEAN_AND_MEAN`, which only matters on Windows. That works against your branch name `upgrade_to_cross_platform`.
- A precompiled header makes no sense for a library made only of headers.
- `.vcxproj` builds only with MSBuild on Windows. The cross-platform build definition should be CMake. Visual Studio and Rider both open CMake projects directly, so you don't lose your IDE.

A suggested layout:

```
CPP/Core/
├── CMakeLists.txt
├── conanfile.py
├── include/Fundamentals/
│   ├── Fundamentals.hpp          ← umbrella header, includes all below (like index.ts)
│   ├── ComputerNetworking.hpp
│   ├── DataTypes.hpp
│   ├── DateTime.hpp
│   ├── EmailAddress.hpp
│   └── IDs.hpp
└── tests/
    └── StaticChecks.cpp
```

The `include/Fundamentals/` folder is intentional: users write `#include <Fundamentals/DateTime.hpp>`, and the folder acts as the namespace for file names. It stops a generic name like `DateTime.hpp` from colliding with another library's header.

---

## 1. `constexpr` vs. macros

**Use `constexpr` only, and don't ship a macro variant.** Offering both doubles your maintenance and gives users nothing in return.

### Performance is identical
For integral constants the compiler substitutes the value directly into the machine instruction (an "immediate operand") in both cases:

```cpp
#define HTTPS_DEFAULT_PORT_MACRO 443
inline constexpr std::uint16_t HTTPS_DEFAULT_PORT = 443;

if (port == HTTPS_DEFAULT_PORT_MACRO) ...   // cmp ax, 443
if (port == HTTPS_DEFAULT_PORT) ...         // cmp ax, 443  ← same code
```

A `constexpr` variable that you only read takes no memory and costs nothing at runtime. So macros offer no performance benefit, only drawbacks.

### Why macros lose on everything else
| Concern | Macro | `constexpr` |
|---|---|---|
| **Type** | None. `#define X 443` is just `int` text, which defeats your minimal-datatype goal | Exactly the type you declare (`std::uint16_t`) |
| **Scope** | Global text replacement, ignores namespaces | Lives in `Fundamentals::…` |
| **Collisions** | Real danger: `<windows.h>` defines `DELETE`, `ERROR`, `IN`, `OUT`, `min`, `max`… | None |
| **Debugger / IDE** | Invisible after preprocessing | Visible, navigable, shows in tooltips |
| **Compile-time checks** | Works in `#if` only | Works in `static_assert`, templates, `if constexpr` |

The one real use for macros is a value needed inside `#if`, or a header that plain **C** code must include. Neither applies here.

### The `inline` in `inline constexpr`
At namespace scope, `constexpr` implies `const`, and `const` implies *internal linkage*: each `.cpp` file gets its own private copy. That only matters if someone takes the address (`&HTTPS_DEFAULT_PORT`), but **`inline constexpr`** (C++17) guarantees exactly one entity across the whole program. Make it a habit for header constants.

### A related naming note
The C++ Core Guidelines (ES.9) advise against `ALL_CAPS` names for non-macros, precisely because they collide with macros. Your `OK` status code, or an all-caps `DELETE`, would break as soon as someone includes `<windows.h>` first. Keeping `ALL_CAPS` for parity with TS/C# is acceptable, but expect that issue. Your lower-case member names (`get`, `badRequest`) are safe.

---

## 2. Choosing datatypes

Use the fixed-width types from `<cstdint>`, never plain `int`/`long`. Their sizes vary by platform (for example, `long` is 4 bytes on Windows and 8 on Linux).

| Constant group | Type | Reason |
|---|---|---|
| Ports, HTTP status codes, `MAXIMAL_CHARACTERS_COUNT` (320) | `std::uint16_t` | Matches C# `ushort` |
| Days/months/hours/minutes counts, ISO 8601 lengths, ID lengths, `MINIMAL_CHARACTERS_COUNT` | `std::uint8_t` | Matches C# `byte` |
| `MAXIMAL/MINIMAL_SUPPORTED_UNIX_MILLISECONDS_AMOUNT` (8.64·10¹⁵) | `std::int64_t` | Needs more than 32 bits, and the minimum is negative |
| HTTP methods, day/month names | `std::string_view` | See below |

### Pitfalls you'll hit

**1. `std::uint8_t` is a `char` in disguise.** It's a typedef for `unsigned char`, so:
```cpp
std::cout << DateTime::DAYS_COUNT_IN_WEEK;   // prints the BEL control character, not "7"!
std::cout << +DateTime::DAYS_COUNT_IN_WEEK;  // unary + promotes to int → prints 7
```
Mention this in your README, because users will hit it.

**2. Integer promotion.** `uint8_t + uint8_t` gives `int`. Arithmetic in C++ never happens in types narrower than `int`. This means the narrow type doesn't make arithmetic faster. It gives **type correctness**, and saves **memory when users store values** in structs or arrays. Be honest about this in the docs: a constant itself occupies 0 bytes either way.

**3. There's no 3-byte integer.** For `MAXIMAL_VALUE_OF_3_BYTES_INTEGER` (8 388 607) the smallest type that holds it is `std::int32_t`.

**4. The `INT64_MIN` trap.** This line does **not** do what it looks like:
```cpp
inline constexpr std::int64_t MINIMAL_VALUE_OF_8_BYTES_INTEGER = -9223372036854775808; // ✗
```
`9223372036854775808` is parsed *first* as a positive literal, and it's too big for `int64_t`. The minus is applied afterwards. Use `std::numeric_limits<std::int64_t>::min()`, which is `constexpr`. The other min/max constants should also just alias `std::numeric_limits<…>`, so you have a single source of truth.
**5. "16-byte float" doesn't exist portably.** `long double` is 8 bytes on MSVC, 16 on GCC/Linux x86-64 (and really only 80 bits inside). Your `FloatingPointDataTypes::sixteenBytes` has no reliable C++ counterpart. C++23 `<stdfloat>` adds `std::float128_t` as an optional type.

**6. Use digit separators:** `65'535`, `8'640'000'000'000'000`. They're free and readable.

---

## 3. Mapping each construct

### Plain numeric constants → `inline constexpr` in a namespace
A C# `static class` holding only constants maps to a C++ **namespace**, not a class:

```cpp
#pragma once
#include <cstdint>

namespace Fundamentals::DateTime {

  inline constexpr std::uint8_t DAYS_COUNT_IN_WEEK = 7;
  inline constexpr std::uint8_t MAXIMAL_DAYS_IN_MONTH = 31;
  inline constexpr std::uint8_t MONTHS_COUNT_IN_YEAR = 12;
  // ...
}
```

### String constants → `std::string_view`
`constexpr std::string_view` points to a string literal baked into the binary: no allocation, no constructor at startup, and `.size()` is known at compile time.
- **Don't** use `std::string`. It allocates, and a `constexpr std::string` can't survive past compile time.
- `const char*` also works, but loses the length and the comparison operators.

```cpp
namespace Fundamentals::ComputerNetworking::HTTP_Methods {
  inline constexpr std::string_view get     = "GET";
  inline constexpr std::string_view delete_ = "DELETE";  // `delete` is a keyword
  // ...
}
```
You already met this problem in C# with `continue_`. In C++, `delete` is also reserved.

A more C++-idiomatic alternative for performance-critical code is `enum class HTTP_Method : std::uint8_t { get, post, … }` plus a `constexpr std::string_view toString(HTTP_Method)`. Comparing 1-byte enums is faster than comparing strings. For a constants library meant to mirror the TS/C# versions, string constants are fine.

### HTTP status code categories → `inline namespace` (no duplication)
In C# you repeat every code twice (top level and inside `ClientErrors` etc.). C++ has a feature that removes the duplication:

```cpp
namespace Fundamentals::ComputerNetworking::HTTP_StatusCodes {

  inline namespace InformationalResponses {
    inline constexpr std::uint16_t continue_ = 100;
    inline constexpr std::uint16_t switchingProtocols = 101;
    // ...
  }

  inline namespace ClientErrors {
    inline constexpr std::uint16_t badRequest = 400;
    inline constexpr std::uint16_t notFound = 404;
    // ...
  }
}

// Both work, with each value defined once:
HTTP_StatusCodes::notFound;
HTTP_StatusCodes::ClientErrors::notFound;
```

Members of an `inline namespace` are also visible as members of the enclosing namespace. That's a nice exercise for learning name lookup.

*Design alternative:* `enum class HTTP_StatusCode : std::uint16_t`. It's stronger typed (you can't accidentally compare it with a port), but every comparison with a raw `int` from a third-party HTTP library needs a cast. For a library meant to interoperate with arbitrary HTTP clients, I lean towards constants, like your C# version does.

Side note: C# calls the category `ServerError` while TS uses `ServerErrors…`. Pick one before you create a third spelling.

### TS string enums (`IntegerDataTypes`, `FloatingPointDataTypes`) → `enum class : std::uint8_t`
```cpp
enum class IntegerDataTypes : std::uint8_t { oneByte, twoBytes, threeBytes, fourBytes, eightBytes };
```
Specify the underlying type explicitly. Otherwise it defaults to `int`.

### Email regex: the hard case
`std::regex` is **not** `constexpr`, it's built at runtime, and it's notoriously slow in all three major standard libraries. Options:
1. **Recommended for Core:** expose only the pattern as `inline constexpr std::string_view EMAIL_ADDRESS_VALID_PATTERN = R"(^\w+…$)";` (a raw string literal, so no escaping hell). Users compile it with whatever regex engine they use (std, Boost, RE2, PCRE2).
2. If you want a ready object, use a function with a local static:
   ```cpp
   inline const std::regex& emailAddressValidPattern() {
     static const std::regex pattern{ EMAIL_ADDRESS_VALID_PATTERN.data(), std::regex::icase | std::regex::optimize };
     return pattern;   // constructed once, thread-safe since C++11
   }
   ```
   Avoid a global `std::regex` object, which runs a constructor before `main` and risks the "static initialization order fiasco".
3. For maximum performance there's **CTRE** (compile-time regular expressions), which builds the matcher at compile time. It adds a dependency, so treat it as an optional extra rather than part of Core.

### Things to skip
- `Integer` / `Float` empty classes: nothing to port.
- `MAXIMAL/MINIMAL_SUPPORTED_UNIX_MILLISECONDS_AMOUNT`: these describe the range of the **JavaScript `Date` object**. Your C# version already left them out, and they mean nothing in C++ (`std::chrono` has different limits). I'd skip them too.

---

## 4. C++ standard version

- **C++17 is the minimum** you need (`inline` variables, `std::string_view`, nested `namespace A::B`).
- Your `.vcxproj` uses C++20. For a *library*, a lower minimum means more potential users, and nothing here needs C++20.
- My suggestion: require C++17, and test with 17, 20 and 23.

---

## 5. Testing: `static_assert`

For a constants library, most tests can run at compile time. If it compiles, the test passed:

```cpp
#include <Fundamentals/Fundamentals.hpp>
#include <type_traits>

using namespace Fundamentals;

static_assert(ComputerNetworking::HTTPS_DEFAULT_PORT == 443);
static_assert(std::is_same_v<decltype(ComputerNetworking::HTTPS_DEFAULT_PORT), const std::uint16_t>);
static_assert(sizeof(DateTime::DAYS_COUNT_IN_WEEK) == 1);
static_assert(HTTP_StatusCodes::ClientErrors::notFound == HTTP_StatusCodes::notFound);
```

This also verifies your types, which is exactly your concern. For runtime tests (the regex), add doctest or Catch2 later.

Also build with strict warnings (`/W4 /permissive-` on MSVC, `-Wall -Wextra -Wconversion -Wpedantic` on GCC/Clang). `-Wconversion` in particular will teach you a lot about narrowing and the integer promotion pitfalls above.

---

## 6. Distribution: CMake + Conan

You were told correctly: **CMake is a build-system generator, not a package manager.** But I'd adjust the advice in one way: **get the CMake part right first, and treat Conan as a thin layer on top.**

### Step 1: a properly *exportable* CMake target (the most important part)
```cmake
cmake_minimum_required(VERSION 3.21)
project(Fundamentals VERSION 11.0.0 LANGUAGES CXX)

add_library(Fundamentals INTERFACE)                 # INTERFACE = header-only
add_library(Fundamentals::Fundamentals ALIAS Fundamentals)

target_include_directories(Fundamentals INTERFACE
  $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include>
  $<INSTALL_INTERFACE:include>)
target_compile_features(Fundamentals INTERFACE cxx_std_17)

# + install(TARGETS … EXPORT …), install(EXPORT …),
#   CMakePackageConfigHelpers → FundamentalsConfig.cmake
```
With this in place, the library works with **every** consumption method at once:

| Method | npm/NuGet analogy | Notes |
|---|---|---|
| `FetchContent` (built into CMake) | `npm install github:user/repo` | No package manager needed at all |
| `find_package(Fundamentals)` after install | global install | Uses your exported config |
| **Conan 2** | npm + private registry | Decentralized; you can host your own remote (JFrog Artifactory CE, GitLab package registry) |
| **vcpkg** | NuGet-like, Microsoft | `vcpkg.json` works like `package.json`; strong VS/Rider integration |

### My view on Conan
It's a solid, mature choice. Two things to expect:
1. **Publishing is not like `npm publish`.** Getting into ConanCenter means a pull request to `conan-center-index` with human review. For self-distribution you run your own remote. vcpkg works the same way (PR to `microsoft/vcpkg`, or your own registry).
2. Conan's biggest feature is **binary caching**, building and caching `.lib`/`.so` files per compiler/OS/configuration. A header-only library doesn't use it. Your recipe will be tiny (`package_type = "header-library"`, `no_copy_source = True`, `self.info.clear()` in `package_id`).

**Recommendation:** CMake with a proper export (step 1) + Conan recipe + document `FetchContent` usage in the README. Adding a vcpkg port later is cheap. C++ users are split between Conan and vcpkg, and a header-only library can easily serve both.

---

## 7. Other notes

- **Don't write `using namespace` in headers.** It forces those names on everyone who includes them.
- Use `#pragma once`. All major compilers support it, and it's simpler than include guards.
- Mark future `constexpr` helper functions (for example `isClientError(code)`) as `[[nodiscard]] constexpr … noexcept`.
- Your `Localizations/Japanese` and `Russian` folders can later become separate header-only targets (or Conan *components*) that depend on `Fundamentals::Fundamentals`.
- Keep the version number in sync across `package.json`, `.csproj` (currently `11.0.0-alpha.1`), CMake `project(VERSION …)` and `conanfile.py`.
- Unrelated: the new C# project file is named `CShrarp-Core.csproj`. That's probably a typo for "CSharp", and it's better fixed before it spreads into references.

### Suggested order of work
1. Replace the `.vcxproj` scaffold with `CMakeLists.txt` + `include/Fundamentals/`.
2. Port `IDs.hpp` and `DateTime.hpp` first. They're trivial and let you learn `inline constexpr`, `<cstdint>` and the `uint8_t` printing pitfall.
3. Port `ComputerNetworking.hpp` (practice `string_view`, `inline namespace` and keyword collisions).
4. Port `DataTypes.hpp` (`numeric_limits` and the `INT64_MIN` trap).
5. Port `EmailAddress.hpp` (the regex decision).
6. Add the `static_assert` test file and strict warnings.
7. Add CMake install/export, then `conanfile.py`, then test the library from a separate small consumer project via both `FetchContent` and Conan.

When you're ready to start, I can review each header as you write it, which is probably the best way to learn here.