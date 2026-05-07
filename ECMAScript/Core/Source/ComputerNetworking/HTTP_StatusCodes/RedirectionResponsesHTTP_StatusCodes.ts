/* [ Reference ] https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#redirection_messages */

export enum RedirectionResponsesHTTP_StatusCodes {
  multipleChoices = 300,
  movedPermanently = 301,
  found = 302,
  seeOther = 303,
  notModified = 304,
  useProxy = 305,
  unused = 306,
  temporaryRedirect = 307,
  permanentRedirect = 308
}
