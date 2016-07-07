namespace MorseCodeTranslator.Languages
{
    public interface ILanguage
    {
        string ToMorse(string value);
        string FromMorse(string value);
    }
}
