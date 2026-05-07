I've read both the C# and npm sources. Now I'm checking a few line numbers before writing the review.

# Review of the `Fundamentals` C# package

I compared `CSharp/Core` with `ECMAScript/Core/Source` (fundamental-constants 0.9.0). I didn't change any code.

---

## 1. Constants missing compared with the npm package

| npm export | In C#? | Comment |
|---|---|---|
| `IntegerDataTypes`, `FloatingPointDataTypes` | ❌ | These describe data types in general (for example database column types), not anything specific to ECMAScript. They should be ported. |
| `MAXIMAL/MINIMAL_VALUE_OF_[UNSIGNED_]N_BYTE(S)_INTEGER` | ❌ | Most of these already exist in .NET as `sbyte.MaxValue`, `int.MinValue` and so on. The **3-byte** limits (8 388 607, −8 388 608, 16 777 215) have no .NET equivalent and are worth porting. You could port all of them so both packages stay in step. |
| `MAXIMAL/MINIMAL_SUPPORTED_UNIX_MILLISECONDS_AMOUNT` | ❌ | Leaving these out is correct: ±8.64·10¹⁵ is the range of the JavaScript `Date` object. |
| `Float`, `Integer`, `*Constructor` | ❌ | Leaving these out is correct: they are TypeScript type markers. |
| `CHARACTERS_COUNT_IN_FULL_ISO8601_STRING = 24` | ✅ | ⚠️ 24 is the length of JavaScript's `toISOString()` output (`YYYY-MM-DDTHH:mm:ss.sssZ`). The .NET `"O"` format produces 28–33 characters. Either document the exact format this constant describes or treat it as ECMAScript-specific. |

## 2. Defects and inconsistencies

- **`ComputerNetworking.cs:3`**: the class is `public class`, not `static`, so it can be instantiated. Every other container class is `static`.
- **`ComputerNetworking.cs:163`**: the class is named `ServerError`, but the README, npm (`ServerErrorsHTTP_StatusCodes`) and the sibling classes (`ClientErrors`) all use the plural.
- **`DateTime.cs:3`**: `Fundamentals.DateTime` clashes with `System.DateTime`. Any consumer project with `ImplicitUsings` enabled (the default) that adds `using Fundamentals;` gets error **CS0104 "ambiguous reference"** wherever it writes `DateTime`. This is a usability problem rather than a naming preference: consumers would have to add aliases. Consider a name or namespace that doesn't collide with the standard library.
- **README is out of date:**
  - The Email table (lines 217–219) still says `Email.*`; the class is now `EmailAddress`.
  - `DateTime` and `IDs` have no tables at all.
  - The informational table lists the key `continue`, but the code has `continue_`. You could use the verbatim identifier `@continue`, which keeps the original key.
  - The install command pins `1.0.0`, but the csproj says `11.0.0-alpha.1`.
- **csproj:** the file name has a typo (`Fundamentals-CShrarp-Core.csproj`).
- **`HTTP_Methods.create = "CREATE"`**: CREATE is not an HTTP method in RFC 9110. It comes from the npm package, so fix it in both places.

## 3. Performance and memory

**Good news: the constants already cost nothing at runtime.** A `const` is copied into the consumer's compiled code at build time. Nested `static class`es that contain only `const`s are never loaded, never initialised and never allocate memory. That means:

- The duplicated status codes (flat list plus categories) only make the DLL's metadata a few KB bigger; there is no runtime cost. For maintenance, though, define each value once and reference it, e.g. `public const ushort OK = SuccessfulResponses.OK;`. That keeps one source of truth at the same zero cost.
- `byte` and `ushort` for counts **save no memory**. A constant is always loaded as a 32-bit value. Choose the type for its meaning only.
- One caveat of copying constants: if a value ever changes, consumers only see the new value after they recompile. That's acceptable for values that truly never change.

**The only real runtime cost is `EmailAddress.VALID_PATTERN` (`EmailAddress.cs:10`):**

1. **`RegexOptions.Compiled` generates code at runtime** on first use, which costs startup time and memory. Under NativeAOT it falls back to the slower interpreter. Use `[GeneratedRegex]` instead (on a `static partial` property, supported in .NET 9+), so the regex is generated at build time.
2. **Catastrophic backtracking (ReDoS) risk.** The part `\w+(?:[.-]?\w+)*` is the classic exponential pattern. An input like `"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa!"` can freeze the thread. Rewriting it as `\w+(?:[.-]\w+)*` matches **exactly the same strings** (because `\w+\w+` is the same as `\w+`) and removes the ambiguity. Also consider `RegexOptions.NonBacktracking` or a match timeout. The same fix applies to npm.
3. **It behaves differently from npm.** In JavaScript, `\w` matches only ASCII even with the `/u` flag. In .NET, `\w` matches Unicode letters, so .NET accepts addresses that npm rejects. Use `[A-Za-z0-9_]` (or `RegexOptions.ECMAScript`).
4. `IgnoreCase` does nothing here, because the pattern contains no letters. Dropping it makes the regex slightly faster.

**Packaging:**
- Add `<IsTrimmable>true</IsTrimmable>` and `<IsAotCompatible>true</IsAotCompatible>`.
- Building for both `net10.0` and `net11.0` gives two identical DLLs, because nothing in the package uses .NET 11 features. A single `net10.0` build also runs on .NET 11.
- Add `<GenerateDocumentationFile>` and XML doc comments carrying over the npm reference links (MDN, Stack Overflow).

**If you switch to enumeration-like classes (section 5):** each member becomes a real object, created the first time the type is used. For 7–60 members that's only a few KB. Still, build any collections used for iteration (`All`, lookup dictionaries) lazily, for example in a nested holder class, so code that only uses `DaysOfWeekNames.sunday` never pays for them.

## 4. English and word usage

- **`HOURS_COUNT_IN_STELLAR_DAY`: this is factually wrong.** A stellar (or sidereal) day lasts about **23 h 56 min 4 s**. 24 hours is the **mean solar day**. The same error is in npm.
- **`MAXIMAL_DAYS_IN_MONTH`** is missing `COUNT`, unlike `DAYS_COUNT_IN_WEEK` and `MONTHS_COUNT_IN_YEAR`. `MAXIMAL_DAYS_COUNT_IN_MONTH` would be consistent.
- **`UNIVERSAL_UNIQUE_ID`**: the standard term is "**Universally** Unique Identifier", with the adverb.
- **Status code names:** RFC 9110 renamed 413 to "Content Too Large" and 422 to "Unprocessable Content". The old names are still widely recognised, so this is optional.
- **`MonthsNames` and `DaysOfWeekNames` are correct under your rule.** "MonthNames" would mean the names of *one* month, so keep them as they are.
- **README:**
  - "All values **has**" → **have**
  - "has been **realized**" → **released**
  - "versions of .NET **was**" → **were** (twice)
  - "**Information** Responses" → **Informational**
  - "without being stored **to** the constants" → **in**
  - "Such constants even should be out-of-box" → "should even be available out of the box"

---

## 5. Enumeration-like classes: how many of the 5 TypeScript requirements C# can meet

**The current approach** (a `static class` of `const string`) meets **2 of 5**:

| # | Requirement | Current | Native C# `enum` | "Smart enum" class |
|---|---|---|---|---|
| 1 | String values | ✅ | ❌ (whole numbers only; a string can only be attached as an attribute) | ✅ |
| 2 | Value differs from the key | ✅ | ✅ for numbers (`notFound = 404`) | ✅ |
| 3 | Logs the value (`"SUNDAY"`) | ✅ | ❌ prints the key (`sunday`); `ToString()` cannot be overridden | ✅ by overriding `ToString()` |
| 4 | Works as a parameter type that rejects plain strings | ❌ the parameter is just `string`, so any string is accepted | ✅ | ✅ with a private constructor |
| 5 | Iterate keys and values | ❌ needs reflection | ✅ `Enum.GetNames<T>()` / `GetValues<T>()` | ✅ with an explicit static list |

**All 5 are achievable in C#, but only with a "smart enum" class.** Microsoft uses this pattern itself: **`System.Net.Http.HttpMethod`** is a sealed class with static instances like `HttpMethod.Get`, and `ToString()` returns `"GET"`. Sketch:

```csharp
public sealed class DaysOfWeekNames
{
  public static readonly DaysOfWeekNames sunday = new(nameof(sunday), "SUNDAY");
  public static readonly DaysOfWeekNames monday = new(nameof(monday), "MONDAY");
  // …

  public string Key { get; }
  public string Value { get; }
  private DaysOfWeekNames(string key, string value) { Key = key; Value = value; }   // #4: no outside instances

  public override string ToString() => Value;                                       // #3
  public static implicit operator string(DaysOfWeekNames d) => d.Value;             // passes to string APIs; no conversion back from string
  public static bool TryParse(string? value, [NotNullWhen(true)] out DaysOfWeekNames? result) { … }

  private static class Cache { internal static readonly DaysOfWeekNames[] All = [sunday, monday, /*…*/]; } // built lazily
  public static ReadOnlySpan<DaysOfWeekNames> All => Cache.All;                     // #5
}
```

**What you give up compared with `const` or a native `enum`, because the members are no longer compile-time constants:**
- They can't be `case` labels or `switch` patterns. Switch on `.Value` instead.
- They can't be attribute arguments or default parameter values.
- The compiler can't warn when a `switch` misses a member.
- JSON serialisation needs a small custom `JsonConverter`.
- Prefer `sealed class` over `struct`. With a struct, `default(DaysOfWeekNames)` would create an invalid member with a `null` value. With a class, nullable reference types will flag `null`.
- To avoid copying `TryParse`, `All` and the JSON converter into every enum, put them in a generic base type, or later in a source generator. Don't add a third-party dependency such as Ardalis.SmartEnum to a "fundamentals" package.

**Recommendation by kind:**
- **String enums** (`HTTP_Methods`, `DaysOfWeekNames`, `MonthsNames`, `IntegerDataTypes`, `FloatingPointDataTypes`): use smart enums. Optionally keep a nested class of `const string`s alongside them for `switch` and attributes.
- **Numeric enums** (`HTTP_StatusCodes` and its categories): use a native `enum HTTP_StatusCodes : ushort`. It meets #2, #4 and #5 at zero cost. It fails only #3 (it logs `notFound`, not `404`), and `$"{code:D}"` prints the number. The category enums would be separate types, just like in TypeScript.