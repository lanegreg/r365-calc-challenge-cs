using System;


namespace Step12.Common
{
  public class InputFormat
  {
    private readonly string _delimitersToParse = String.Empty;
    private readonly string _numbersToParse = String.Empty;


    public InputFormat(string stringInput)
    {
      IsCustom = stringInput.StartsWith("//", StringComparison.InvariantCultureIgnoreCase);

      if (IsCustom)
      {
        var parts = stringInput
            .Replace("\\n", "\n")
            .Split(new[] { '\n' });

        _delimitersToParse = parts[0].TrimStart('/');
        _numbersToParse = parts[1].Trim();
      }
      else
        _numbersToParse = stringInput;
    }


    public string GetNumbersToParse()
    {
      return _numbersToParse;
    }

    public string GetDelimitersToParse()
    {
                
      return _delimitersToParse;
    }

    public bool IsCustom { get; private set; }
  }
}
