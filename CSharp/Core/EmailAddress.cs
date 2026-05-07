namespace Fundamentals;
  
  
public static class EmailAddress
{
  
  public const byte MINIMAL_CHARACTERS_COUNT = 3; 
  public const ushort MAXIMAL_CHARACTERS_COUNT = 320;
  
  public static readonly System.Text.RegularExpressions.Regex VALID_PATTERN = new(
    @"^\w+(?:[.-]?\w+)*@\w+(?:[.-]?\w+)*(?:\.\w{2,3})+$", 
    options: System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase
  );
  
  
}
