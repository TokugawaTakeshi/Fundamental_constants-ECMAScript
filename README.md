Fundamental constants and enumerations.

Some of their values are commonly known, for example the `HOURS_COUNT_IN_STELLAR_DAY` is **24** and `MAXIMAL_DAYS_IN_MONTH` is **31**.
However, without being stored to the constants with clear names, it will be the 
  [magic numbers](https://en.wikipedia.org/wiki/Magic_number_(programming)).


## Installation

```shell
npm i fundamental-constants -E
```


## Content
### Computer Networking

| Constant Name                | Value |
|------------------------------|-------|
| `HTTP_DEFAULT_PORT`          | 80    |
| `HTTPS_DEFAULT_PORT`         | 443   |
| `NETWORK_PORT_MAXIMAL_VALUE` | 65535 |
| `NETWORK_PORT_MINIMAL_VALUE` | 1     |


#### Enumerations
##### `HTTP_Methods`

| Key      | Value     |
|----------|-----------|
| get      | "GET"     |
| post     | "POST"    |
| create   | "CREATE"  |
| put      | "PUT"     |
| delete   | "DELETE"  |
| options  | "OPTIONS" |
| head     | "HEAD"    |
| connect  | "CONNECT" |
| trace    | "TRACE"   |
| patch    | "PATCH"   |

##### HTTP Status Codes
###### `HTTP_StatusCodes` — All HTTP Status Codes

| Key                           | Value |
|-------------------------------|-------|
| continue                      | 100   |
| switchingProtocols            | 101   |
| processing                    | 102   |
| earlyHints                    | 103   |
| OK                            | 200   |
| created                       | 201   |
| accepted                      | 202   |
| nonAuthoritativeInformation   | 203   |
| noContent                     | 204   |
| resetContent                  | 205   |
| partialContent                | 206   |
| multiStatus                   | 207   |
| alreadyReported               | 208   |
| IM\_Used                      | 226   |
| multipleChoices               | 300   |
| movedPermanently              | 301   |
| found                         | 302   |
| seeOther                      | 303   |
| notModified                   | 304   |
| useProxy                      | 305   |
| unused                        | 306   |
| temporaryRedirect             | 307   |
| permanentRedirect             | 308   |
| badRequest                    | 400   |
| unauthorized                  | 401   |
| paymentRequired               | 402   |
| forbidden                     | 403   |
| notFound                      | 404   |
| methodNotAllowed              | 405   |
| notAcceptable                 | 406   |
| proxyAuthenticationRequired   | 407   |
| requestTimeout                | 408   |
| conflict                      | 409   |
| gone                          | 410   |
| lengthRequired                | 411   |
| preconditionFailed            | 412   |
| payloadTooLarge               | 413   |
| URI\_TooLong                  | 414   |
| unsupportedMediaType          | 415   |
| rangeNotSatisfiable           | 416   |
| expectationFailed             | 417   |
| IAmATeapot                    | 418   |
| misdirectedRequest            | 421   |
| unprocessableEntity           | 422   |
| locked                        | 423   |
| failedDependency              | 424   |
| tooEarly                      | 425   |
| upgradeRequired               | 426   |
| preconditionRequired          | 428   |
| tooManyRequests               | 429   |
| requestHeaderFieldsTooLarge   | 431   |
| unavailableForLegalReasons    | 451   |
| internalServerError           | 500   |
| notImplemented                | 501   |
| badGateway                    | 502   |
| serviceUnavailable            | 503   |
| gatewayTimeout                | 504   |
| HTTP\_VersionNotSupported     | 505   |
| variantAlsoNegotiates         | 506   |
| insufficientStorage           | 507   |
| loopDetected                  | 508   |
| notExtended                   | 510   |
| networkAuthenticationRequired | 511   |


###### `InformationalResponsesHTTP_StatusCodes` — Information Responses

| Key                           | Value |
|-------------------------------|-------|
| continue                      | 100   |
| switchingProtocols            | 101   |
| processing                    | 102   |
| earlyHints                    | 103   |


###### `SuccessfulResponsesHTTP_StatusCodes` — Successful Responses

| Key                           | Value |
|-------------------------------|-------|
| OK                            | 200   |
| created                       | 201   |
| accepted                      | 202   |
| nonAuthoritativeInformation   | 203   |
| noContent                     | 204   |
| resetContent                  | 205   |
| partialContent                | 206   |
| multiStatus                   | 207   |
| alreadyReported               | 208   |
| IM\_Used                      | 226   |


###### `RedirectionResponsesHTTP_StatusCodes` — Redirection Messages

| Key                           | Value |
|-------------------------------|-------|
| multipleChoices               | 300   |
| movedPermanently              | 301   |
| found                         | 302   |
| seeOther                      | 303   |
| notModified                   | 304   |
| useProxy                      | 305   |
| unused                        | 306   |
| temporaryRedirect             | 307   |
| permanentRedirect             | 308   |


###### `ClientErrorsHTTP_StatusCodes` — Client Error Responses

| Key                           | Value |
|-------------------------------|-------|
| badRequest                    | 400   |
| unauthorized                  | 401   |
| paymentRequired               | 402   |
| forbidden                     | 403   |
| notFound                      | 404   |
| methodNotAllowed              | 405   |
| notAcceptable                 | 406   |
| proxyAuthenticationRequired   | 407   |
| requestTimeout                | 408   |
| conflict                      | 409   |
| gone                          | 410   |
| lengthRequired                | 411   |
| preconditionFailed            | 412   |
| payloadTooLarge               | 413   |
| URI\_TooLong                  | 414   |
| unsupportedMediaType          | 415   |
| rangeNotSatisfiable           | 416   |
| expectationFailed             | 417   |
| IAmATeapot                    | 418   |
| misdirectedRequest            | 421   |
| unprocessableEntity           | 422   |
| locked                        | 423   |
| failedDependency              | 424   |
| tooEarly                      | 425   |
| upgradeRequired               | 426   |
| preconditionRequired          | 428   |
| tooManyRequests               | 429   |
| requestHeaderFieldsTooLarge   | 431   |
| unavailableForLegalReasons    | 451   |


###### `ServerErrorsHTTP_StatusCodes` — Server Error Responses

| Key                           | Value |
|-------------------------------|-------|
| internalServerError           | 500   |
| notImplemented                | 501   |
| badGateway                    | 502   |
| serviceUnavailable            | 503   |
| gatewayTimeout                | 504   |
| HTTP\_VersionNotSupported     | 505   |
| variantAlsoNegotiates         | 506   |
| insufficientStorage           | 507   |
| loopDetected                  | 508   |
| notExtended                   | 510   |
| networkAuthenticationRequired | 511   |


### DataTypes
#### IntegerDataTypes

| Key                      | Value                  |
|--------------------------|------------------------|
| `OneByte\_\_8\_Bits`     | "1\_BYTE\_\_8\_BITS"   |
| `TwoBytes\_\_16\_Bits`   | "2\_BYTES\_\_16\_BITS" |
| `ThreeBytes\_\_24\_Bits` | "3\_BYTES\_\_24\_BITS" |
| `FourBytes\_\_32\_Bits`  | "4\_BYTES\_\_32\_BITS" |
| `EightBytes\_\_64\_Bits` | "8\_BYTES\_\_64\_BITS" |


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

| Constant name                                             | Value |
|-----------------------------------------------------------|-------|
| `MAXIMAL_CHARACTERS_COUNT_IN_DATE_PART_OF_ISO8601_STRING` | 10    |
| `CHARACTERS_COUNT_IN_FULL_ISO8601_STRING`                 | 24    |


### Email


| Constant name                               | Value                                                  |
|---------------------------------------------|--------------------------------------------------------|
| `EMAIL_ADDRESS_VALID_PATTERN`               | `/^\w+(?:[.-]?\w+)*@\w+(?:[.-]?\w+)*(?:\.\w{2,3})+$/u` |
| `MINIMAL_CHARACTERS_COUNT_OF_EMAIL_ADDRESS` | 3                                                      |
