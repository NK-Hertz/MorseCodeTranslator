namespace MorseCodeTranslator
{
    using Languages;

    public class Translator
    {
        private ILanguage language;

        public Translator(ILanguage language)
        {
            this.language = language;
        }

        public string LanguageName
        {
            get { return this.language.GetType().Name; }
        }

        public string Translate(string message, bool toMorseCode)
        {
            string result;
            if (toMorseCode)
            {
                result = language.ToMorse(message);
            }
            else
            {
                result = language.FromMorse(message);
            }

            return result;
        }
    }
}
