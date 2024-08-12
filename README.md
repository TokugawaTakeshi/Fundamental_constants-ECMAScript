Fundamental constants and enumerations.

Some of their values are commonly known, for example the `HOURS_COUNT_IN_STELLAR_DAY` is **24** and `MAXIMAL_DAYS_IN_MONTH` is **31**.
However, without being stored to the constants with clear names, it will be the 
  [magic numbers](https://en.wikipedia.org/wiki/Magic_number_(programming)).


## Installation

```shell
npm i fundamental-constants -E
```


## Content
### Compute networking

| Constant name                | Value |
|------------------------------|-------|
| `HTTP_DEFAULT_PORT`          | 80    |
| `HTTPS_DEFAULT_PORT`         | 443   |
| `NETWORK_PORT_MAXIMAL_VALUE` | 65535 |
| `NETWORK_PORT_MINIMAL_VALUE` | 1     |


### Date and Time

| Constant name                                | Value             |
|----------------------------------------------|-------------------|
| `DAYS_COUNT_IN_WEEK`                         | 7                 |
| `HOURS_COUNT_IN_STELLAR_DAY`                 | 24                |
| `MAXIMAL_DAYS_IN_MONTH`                      | 31                |
| `MAXIMAL_SUPPORTED_UNIX_MILLISECONDS_AMOUNT` | 8640000000000000  |
| `MINIMAL_SUPPORTED_UNIX_MILLISECONDS_AMOUNT` | -8640000000000000 |
| `MINUTES_COUNT_IN_HOUR`                      | 60                |
| `MONTHS_COUNT_IN_YEAR`                       | 12                |
| `SECONDS_COUNT_IN_MINUTE`                    | 60                |

#### Enumerations
##### `DaysOfWeekNames`

| Key       | Value       |
|-----------|-------------|
| sunday    | "SUNDAY"    |
| monday    | "MONDAY"    |
| tuesday   | "TUESDAY"   |
| wednesday | "WEDNESDAY" |
| thursday  | "THURSDAY"  |
| friday    | "FRIDAY"    |
| saturday  | "SATURDAY"  |

##### `MonthsNames`

| Key       | Value       |
|-----------|-------------|
| january   | "JANUARY"   |
| february  | "FEBRUARY"  |
| march     | "MARCH"     |
| april     | "APRIL"     |
| may       | "MAY"       |
| june      | "JUNE"      |
| july      | "JULY"      |
| august    | "AUGUST"    |
| september | "SEPTEMBER" |
| october   | "OCTOBER"   |
| november  | "NOVEMBER"  |
| december  | "DECEMBER"  |


#### ISO8601

| Constant name                                     | Value |
|---------------------------------------------------|-------|
| `CHARACTERS_COUNT_IN_DATE_PART_OF_ISO8601_STRING` | 10    |
| `CHARACTERS_COUNT_IN_FULL_ISO8601_STRING`         | 24    |


### Email


| Constant name                               | Value                                                  |
|---------------------------------------------|--------------------------------------------------------|
| `EMAIL_ADDRESS_VALID_PATTERN`               | `/^\w+(?:[.-]?\w+)*@\w+(?:[.-]?\w+)*(?:\.\w{2,3})+$/u` |
| `MINIMAL_CHARACTERS_COUNT_OF_EMAIL_ADDRESS` | 3                                                      |
