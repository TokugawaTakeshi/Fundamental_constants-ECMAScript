namespace Fundamentals;

public static class DateTime
{
  
  public const byte DAYS_COUNT_IN_WEEK = 7;
  public const byte MAXIMAL_DAYS_IN_MONTH = 31;

  public const byte MONTHS_COUNT_IN_YEAR = 12;
  
  public const byte HOURS_COUNT_IN_STELLAR_DAY = 24;
  public const byte NOON_HOUR_NUMBER_IN_24_HOUR_FORMAT = 12;

  public const byte MINUTES_COUNT_IN_HOUR = 60;
  
  public const byte SECONDS_COUNT_IN_MINUTE = 60;

  public static class DaysOfWeekNames
  {
    public const string sunday = "SUNDAY";
    public const string monday = "MONDAY";
    public const string tuesday = "TUESDAY";
    public const string wednesday = "WEDNESDAY";
    public const string thursday = "THURSDAY";
    public const string friday = "FRIDAY";
    public const string saturday = "SATURDAY";
  } 
  
  public static class MonthsNames {
    public const string january = "JANUARY";
    public const string february = "FEBRUARY";
    public const string march = "MARCH";
    public const string april = "APRIL";
    public const string may = "MAY";
    public const string june = "JUNE";
    public const string july = "JULY";
    public const string august = "AUGUST";
    public const string september = "SEPTEMBER";
    public const string october = "OCTOBER";
    public const string november = "NOVEMBER";
    public const string december = "DECEMBER";
  }
  
  public const byte CHARACTERS_COUNT_IN_FULL_ISO8601_STRING = 24;
  public const byte  MAXIMAL_CHARACTERS_COUNT_IN_DATE_PART_OF_ISO8601_STRING = 10;
  
}
