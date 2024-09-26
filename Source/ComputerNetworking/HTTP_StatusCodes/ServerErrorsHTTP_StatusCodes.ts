/* [ Reference ] https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses */

export enum ServerErrorsHTTP_StatusCodes {
  internalServerError = 500,
  notImplemented = 501,
  badGateway = 502,
  serviceUnavailable = 503,
  gatewayTimeout = 504,
  HTTP_VersionNotSupported = 505,
  variantAlsoNegotiates = 506,
  insufficientStorage = 507,
  loopDetected = 508,
  notExtended = 510,
  networkAuthenticationRequired = 511
}
