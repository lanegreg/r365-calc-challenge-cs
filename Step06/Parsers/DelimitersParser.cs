using Step06.Common;


namespace Step06.Parsers
{
  public static class DelimitersParser
  {
    private static readonly char[] DEFAULT_DELIMITERS = { ',', '\n' };


    public static char[] Parse(InputFormat format)
    {
      if (format.IsCustom)
      {
        var delimiters = format
          .GetDelimitersToParse()
          .ToCharArray();

        return delimiters;
      }

      return DEFAULT_DELIMITERS;
    }
  }
}
