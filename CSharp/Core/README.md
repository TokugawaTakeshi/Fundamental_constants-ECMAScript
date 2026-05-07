Fundamental constants and enumerations.

Some of their values are commonly known, for example, the `HOURS_COUNT_IN_STELLAR_DAY` is **24** and 
  `MAXIMAL_DAYS_IN_MONTH` is **31**.
However, without being stored to the constants with clear names, it will be the 
  [magic numbers](https://en.wikipedia.org/wiki/Magic_number_(programming)).
Such constants even should be out-of-box in programming language.


## Installation

```shell
dotnet add package Fundamentals --version 1.0.0
```

### .NET Support

The .NET support policy is simple: the newest major version of **Fundamentals** supports the supported versions
  of .NET.
For instance, when **Fundamentals** of version **1.0.0** has been realized, the .NET 10 and .NET 11 was supported
  by the Microsoft, so these versions of .NET was compatible with version **1.0.0** of **Fundamentals**. 


## Content
### `ComputerNetworking`

| Constant Name                | Value | Type   |
|------------------------------|-------|--------|
| `HTTP_DEFAULT_PORT`          | 80    | ushort |
| `HTTPS_DEFAULT_PORT`         | 443   | ushort |
| `NETWORK_PORT_MAXIMAL_VALUE` | 65535 | ushort |
| `NETWORK_PORT_MINIMAL_VALUE` | 1     | ushort |

#### `ComputerNetworking.HTTP_Methods`

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

#### `ComputerNetworking.HTTP_StatusCodes`

All values has `ushort` type.

| Key                           | Value |
|-------------------------------|-------|
| continue_                     | 100   |
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


###### `ComputerNetworking.HTTP_StatusCodes.InformationalResponses` — Information Responses

| Key                           | Value |
|-------------------------------|-------|
| continue                      | 100   |
| switchingProtocols            | 101   |
| processing                    | 102   |
| earlyHints                    | 103   |


###### `ComputerNetworking.HTTP_StatusCodes.SuccessfulResponses` — Successful Responses

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


###### `ComputerNetworking.HTTP_StatusCodes.RedirectionResponses` — Redirection Messages

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


###### `ComputerNetworking.HTTP_StatusCodes.ClientErrors` — Client Error Responses

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


###### `ComputerNetworking.HTTP_StatusCodes.ServerErrors` — Server Error Responses

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


### Email

| Constant name                    | Type                                 | Value                                                  |
|----------------------------------|--------------------------------------|--------------------------------------------------------|
| `Email.MAXIMAL_CHARACTERS_COUNT` | ushort                               | 320                                                    |
| `Email.MINIMAL_CHARACTERS_COUNT` | byte                                 | 3                                                      |
| `Email.VALID_PATTERN`            | System.Text.RegularExpressions.Regex | `/^\w+(?:[.-]?\w+)*@\w+(?:[.-]?\w+)*(?:\.\w{2,3})+$/u` |
