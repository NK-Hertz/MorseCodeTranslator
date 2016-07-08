namespace MorseCodeTranslator.Languages
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseLanguage
    {
        public static readonly Dictionary<int, string> ArabicNumerals =
            new Dictionary<int, string>
            {
                ['0'] = "-----",
                ['1'] = ".----",
                ['2'] = "..---",
                ['3'] = "...--",
                ['4'] = "....-",
                ['5'] = ".....",
                ['6'] = "-....",
                ['7'] = "--...",
                ['8'] = "---..",
                ['9'] = "----."
            };

        public static readonly Dictionary<char, string> AlphabetSpecialCharacters =
            new Dictionary<char, string>
            {
                ['.'] = ".-.-.-",
                [','] = "--..--",
                ['?'] = "..--..",
                ['`'] = ".----.",
                ['!'] = "-.-.--",
                ['/'] = "-..-.",
                ['{'] = "-.--.",
                ['}'] = "-.--.-",
                ['&'] = ".-...",
                [':'] = "---...",
                [';'] = "-.-.-.",
                ['='] = "-...-",
                ['+'] = ".-.-.",
                ['-'] = "-....-",
                ['_'] = "..--.-",
                ['"'] = ".-..-.",
                ['$'] = "...-..-",
                ['@'] = ".--.-."
            };

        private readonly Dictionary<int, string> numerals;
        private readonly Dictionary<string, int> numeralsFromMorse;
        private readonly Dictionary<char, string> specialCharacters;
        private readonly Dictionary<string, char> specialCharactersFromMorse;

        public BaseLanguage()
        {
            this.numerals = ArabicNumerals;
            this.numeralsFromMorse = ArabicNumerals.ToDictionary(p => p.Value, p => p.Key);
            this.specialCharacters = AlphabetSpecialCharacters;
            this.specialCharactersFromMorse = AlphabetSpecialCharacters.ToDictionary(p => p.Value, p => p.Key);
        }

        public abstract Dictionary<char, string> AlphabetToMorse { get; }

        public abstract Dictionary<string, char> AlphabetFromMorse { get; }

        public virtual Dictionary<int, string> Numerals
        {
            get { return this.numerals; }
        }

        public virtual Dictionary<string, int> NumeralsFromMorse
        {
            get { return this.numeralsFromMorse; }
        }

        public virtual Dictionary<char, string> SpecialCharacters
        {
            get { return this.specialCharacters; }
        }

        public virtual Dictionary<string, char> SpecialCharactersFromMorse
        {
            get { return this.specialCharactersFromMorse; }
        }
    }
}
