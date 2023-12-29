## Fundamentals

Fundamental constants and enumerations.

Some of their values are commonly known, for example the `HOURS_PER_STELLAR_DAY` is **24** and `MAXIMAL_DAYS_IN_MONTH` is **31**.
However without being stored to the constants with clear names, it will be the 
  [magic numbers](https://en.wikipedia.org/wiki/Magic_number_(programming)).


## Installation

```shell
npm i fundamental-constants -E
```


## Content
### Compute networking

| Constant name                | Value |
|------------------------------|-------|
| `NETWORK_PORT_MAXIMAL_VALUE` | 65535 |
| `NETWORK_PORT_MINIMAL_VALUE` | 1     |


### Date and Time

| Constant name           | Value |
|-------------------------|-------|
| `HOURS_PER_STELLAR_DAY` | 24    |
| `MAXIMAL_DAYS_IN_MONTH` | 31    |
| `MINUTES_PER_HOUR`      | 60    |
| `SECONDS_PER_MINUTE`    | 60    |


#### ISO8601

| Constant name                                     | Value |
|---------------------------------------------------|-------|
| `CHARACTERS_COUNT_IN_FULL_ISO8601_STRING`         | 24    |
| `CHARACTERS_COUNT_OF_DATE_PART_IN_ISO8601_STRING` | 10    |


### Email


| Constant name                               | Value |
|---------------------------------------------|-------|
| `MINIMAL_CHARACTERS_COUNT_OF_EMAIL_ADDRESS` | 3     |
