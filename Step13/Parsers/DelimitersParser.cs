using Step13.Common;


namespace Step13.Parsers
{
  public static class DelimitersParser
  {
    private static readonly string[] DEFAULT_DELIMITERS = { ",", "\n" };


    public static string[] Parse(InputFormat format)
    {
      if (format.IsCustom)
      {
        var delimiters = format
          .GetDelimitersToParse()
          .TrimStart('[')
          .TrimEnd(']')
          .Split("][");

        return delimiters;
      }

      return DEFAULT_DELIMITERS;
    }
  }
}
