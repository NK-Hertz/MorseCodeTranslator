namespace MorseCodeTranslator.Languages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bulgarian : ILanguage
    {
        private const char MORSE_CODE_CHAR_SEPARATOR = '/';
        private const char LANGUAGE_WORD_SEPARATOR = ' ';
        
        // or use XML
        public static Dictionary<char, string> Bulgarian_To_Morse
         = new Dictionary<char, string>
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

        public static Dictionary<string, char> Morse_To_Bulgarian = Bulgarian_To_Morse.ToDictionary(p => p.Value, p => p.Key);

        public Bulgarian()
        { }

        public string ToMorse(string value)
        {
            var builder = new StringBuilder();

            var words = value.ToLower().Split(LANGUAGE_WORD_SEPARATOR).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    var currentLetterInMorse = Bulgarian_To_Morse[currentWord[j]];
                    builder.Append(currentLetterInMorse);

                    if (j != currentWord.Length - 1)
                    {
                        builder.Append(MORSE_CODE_CHAR_SEPARATOR);
                    }
                }

                builder.Append(LANGUAGE_WORD_SEPARATOR);
            }

            return builder.ToString().Trim();
        }

        public string FromMorse(string value)
        {
            var builder = new StringBuilder();

            var words = value.Split(LANGUAGE_WORD_SEPARATOR).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i].Split(MORSE_CODE_CHAR_SEPARATOR);
                for (int j = 0; j < currentWord.Length; j++)
                {
                    var currentLetterInLanguage = Morse_To_Bulgarian[currentWord[j]];
                    builder.Append(currentLetterInLanguage);
                }

                builder.Append(LANGUAGE_WORD_SEPARATOR);
            }

            return builder.ToString().Trim();
        }
    }
}
