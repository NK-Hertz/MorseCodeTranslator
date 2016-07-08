namespace MorseCodeTranslator.Languages
{
    using System.Collections.Generic;
    using System.Linq;

    public class English : BaseLanguage
    {
        private static readonly Dictionary<char, string> EnglishAlphabetToMorse =
            new Dictionary<char, string>
            {
                ['a'] = ".-",
                ['b'] = "-...",
                ['c'] = "-.-.",
                ['d'] = "-..",
                ['e'] = ".",
                ['f'] = "..-.",
                ['g'] = "--.",
                ['h'] = "....",
                ['i'] = "..",
                ['j'] = ".---",
                ['k'] = "-.-",
                ['l'] = ".-..",
                ['m'] = "--",
                ['n'] = "-.",
                ['o'] = "---",
                ['p'] = ".--.",
                ['q'] = "--.-",
                ['r'] = ".-.",
                ['s'] = "...",
                ['t'] = "-",
                ['u'] = "..-",
                ['v'] = "...-",
                ['w'] = ".--",
                ['x'] = "-..-",
                ['y'] = "-.--",
                ['z'] = "--..",
            };

        private readonly Dictionary<char, string> alphabetToMorse;
        private readonly Dictionary<string, char> alphabetFromMorse;

        public English()
        {
            this.alphabetToMorse = EnglishAlphabetToMorse;
            this.alphabetFromMorse = EnglishAlphabetToMorse.ToDictionary(p => p.Value, p => p.Key);
        }

        public override Dictionary<char, string> AlphabetToMorse
        {
            get { return this.alphabetToMorse; }
        }

        public override Dictionary<string, char> AlphabetFromMorse
        {
            get { return this.alphabetFromMorse; }
        }
    }
}
