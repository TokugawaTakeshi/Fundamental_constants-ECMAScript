namespace Fundamentals;

public class ComputerNetworking
{
  
  public const ushort NETWORK_PORT_MINIMAL_VALUE = 1;
  public const ushort NETWORK_PORT_MAXIMAL_VALUE = 65535;
  
  public const ushort HTTPS_DEFAULT_PORT = 443;
  public const ushort HTTP_DEFAULT_PORT = 80;
  
  public static class HTTP_Methods {
    public const string get = "GET";
    public const string post = "POST";
    public const string create = "CREATE";
    public const string put = "PUT";
    public const string delete = "DELETE";
    public const string options = "OPTIONS";
    public const string head = "HEAD";
    public const string connect = "CONNECT";
    public const string trace = "TRACE";
    public const string patch = "PATCH";
  }
 
  public static class HTTP_StatusCodes
  {
    
    public const ushort continue_ = 100;
    public const ushort switchingProtocols = 101;
    public const ushort processing = 102;
    public const ushort earlyHints = 103;
    
    public static class InformationalResponses
    {
      public const ushort continue_ = 100;
      public const ushort switchingProtocols = 101;
      public const ushort processing = 102;
      public const ushort earlyHints = 103;
    } 

    public const ushort OK = 200;
    public const ushort created = 201;
    public const ushort accepted = 202;
    public const ushort nonAuthoritativeInformation = 203;
    public const ushort noContent = 204;
    public const ushort resetContent = 205;
    public const ushort partialContent = 206;
    public const ushort multiStatus = 207;
    public const ushort alreadyReported = 208;
    public const ushort IM_Used = 226;

    public static class SuccessfulResponses
    {
      public const ushort OK = 200;
      public const ushort created = 201;
      public const ushort accepted = 202;
      public const ushort nonAuthoritativeInformation = 203;
      public const ushort noContent = 204;
      public const ushort resetContent = 205;
      public const ushort partialContent = 206;
      public const ushort multiStatus = 207;
      public const ushort alreadyReported = 208;
      public const ushort IM_Used = 226;
    }
    
    public const ushort multipleChoices = 300;
    public const ushort movedPermanently = 301;
    public const ushort found = 302;
    public const ushort seeOther = 303;
    public const ushort notModified = 304;
    public const ushort useProxy = 305;
    public const ushort unused = 306;
    public const ushort temporaryRedirect = 307;
    public const ushort permanentRedirect = 308;

    public static class RedirectionResponses
    {
      public const ushort multipleChoices = 300;
      public const ushort movedPermanently = 301;
      public const ushort found = 302;
      public const ushort seeOther = 303;
      public const ushort notModified = 304;
      public const ushort useProxy = 305;
      public const ushort unused = 306;
      public const ushort temporaryRedirect = 307;
      public const ushort permanentRedirect = 308;
    }
    
    public const ushort badRequest = 400;
    public const ushort unauthorized = 401;
    public const ushort paymentRequired = 402;
    public const ushort forbidden = 403;
    public const ushort notFound = 404;
    public const ushort methodNotAllowed = 405;
    public const ushort notAcceptable = 406;
    public const ushort proxyAuthenticationRequired = 407;
    public const ushort requestTimeout = 408;
    public const ushort conflict = 409;
    public const ushort gone = 410;
    public const ushort lengthRequired = 411;
    public const ushort preconditionFailed = 412;
    public const ushort payloadTooLarge = 413;
    public const ushort URI_TooLong = 414;
    public const ushort unsupportedMediaType = 415;
    public const ushort rangeNotSatisfiable = 416;
    public const ushort expectationFailed = 417;
    public const ushort IAmATeapot = 418;
    public const ushort misdirectedRequest = 421;
    public const ushort unprocessableEntity = 422;
    public const ushort locked = 423;
    public const ushort failedDependency = 424;
    public const ushort tooEarly = 425;
    public const ushort upgradeRequired = 426;
    public const ushort preconditionRequired = 428;
    public const ushort tooManyRequests = 429;
    public const ushort requestHeaderFieldsTooLarge = 431;
    public const ushort unavailableForLegalReasons = 451;
    
    public static class ClientErrors {
      public const ushort badRequest = 400;
      public const ushort unauthorized = 401;
      public const ushort paymentRequired = 402;
      public const ushort forbidden = 403;
      public const ushort notFound = 404;
      public const ushort methodNotAllowed = 405;
      public const ushort notAcceptable = 406;
      public const ushort proxyAuthenticationRequired = 407;
      public const ushort requestTimeout = 408;
      public const ushort conflict = 409;
      public const ushort gone = 410;
      public const ushort lengthRequired = 411;
      public const ushort preconditionFailed = 412;
      public const ushort payloadTooLarge = 413;
      public const ushort URI_TooLong = 414;
      public const ushort unsupportedMediaType = 415;
      public const ushort rangeNotSatisfiable = 416;
      public const ushort expectationFailed = 417;
      public const ushort IAmATeapot = 418;
      public const ushort misdirectedRequest = 421;
      public const ushort unprocessableEntity = 422;
      public const ushort locked = 423;
      public const ushort failedDependency = 424;
      public const ushort tooEarly = 425;
      public const ushort upgradeRequired = 426;
      public const ushort preconditionRequired = 428;
      public const ushort tooManyRequests = 429;
      public const ushort requestHeaderFieldsTooLarge = 431;
      public const ushort unavailableForLegalReasons = 451;
    }

    public const ushort internalServerError = 500;
    public const ushort notImplemented = 501;
    public const ushort badGateway = 502;
    public const ushort serviceUnavailable = 503;
    public const ushort gatewayTimeout = 504;
    public const ushort HTTP_VersionNotSupported = 505;
    public const ushort variantAlsoNegotiates = 506;
    public const ushort insufficientStorage = 507;
    public const ushort loopDetected = 508;
    public const ushort notExtended = 510;
    public const ushort networkAuthenticationRequired = 511;
    
    public static class ServerError
    {
      public const ushort internalServerError = 500;
      public const ushort notImplemented = 501;
      public const ushort badGateway = 502;
      public const ushort serviceUnavailable = 503;
      public const ushort gatewayTimeout = 504;
      public const ushort HTTP_VersionNotSupported = 505;
      public const ushort variantAlsoNegotiates = 506;
      public const ushort insufficientStorage = 507;
      public const ushort loopDetected = 508;
      public const ushort notExtended = 510;
      public const ushort networkAuthenticationRequired = 511;
    }
    
  }
  
}
