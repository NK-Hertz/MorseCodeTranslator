namespace MorseCodeTranslator.Languages
{
    using System.Collections.Generic;
    using System.Linq;

    public class Bulgarian : BaseLanguage
    {
        private static readonly Dictionary<char, string> BulgarianAlphabetToMorse = new Dictionary<char, string>
         {
             ['а'] = ".-",
             ['б'] = "-...",
             ['в'] = ".--",
             ['г'] = "--.",
             ['д'] = "-..",
             ['е'] = ".",
             ['ж'] = "...-",
             ['з'] = "--..",
             ['и'] = "..",
             ['й'] = ".---",
             ['к'] = "-.-",
             ['л'] = ".-..",
             ['м'] = "--",
             ['н'] = "-.",
             ['о'] = "---",
             ['п'] = ".--.",
             ['р'] = ".-.",
             ['с'] = "...",
             ['т'] = "-",
             ['у'] = "..-",
             ['ф'] = "..-.",
             ['х'] = "....",
             ['ц'] = "-.-.",
             ['ч'] = "---.",
             ['ш'] = "----",
             ['щ'] = "--.-",
             ['ъ'] = "-..-",
             ['ь'] = "-.--",
             ['ю'] = "..--",
             ['я'] = ".-.-",
         };

        private readonly Dictionary<char, string> alphabetToMorse;
        private readonly Dictionary<string, char> alphabetFromMorse;

        public Bulgarian()
        {
            this.alphabetToMorse = BulgarianAlphabetToMorse;
            this.alphabetFromMorse = BulgarianAlphabetToMorse.ToDictionary(p => p.Value, p => p.Key);
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
