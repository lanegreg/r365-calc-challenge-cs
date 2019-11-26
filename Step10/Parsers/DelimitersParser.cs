using Step10.Common;


namespace Step10.Parsers
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
