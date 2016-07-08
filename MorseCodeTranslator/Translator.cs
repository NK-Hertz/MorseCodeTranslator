namespace MorseCodeTranslator
{
    using System;
    using System.Linq;
    using System.Text;
    using Languages;

    public class Translator
    {
        private const string MORSE_CODE_CHARACTERS = ".-/ ";
        private const char MORSE_CODE_CHAR_SEPARATOR = '/';
        private const char LANGUAGE_WORD_SEPARATOR = ' ';
        private const int CHAR_TO_INT = 48;
        private const int MINUMUM_WORDS_TO_CHECK_IF_MESSAGE_IS_IN_MORSE = 3;

        private BaseLanguage language;

        public Translator(BaseLanguage language)
        {
            this.language = language;
        }

        public string LanguageName
        {
            get { return this.language.GetType().Name; }
        }

        public string Translate(string message)
        {
            if (String.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message can not be null, empty or consist only of white spaces!");
            }

            string result;
            var isInMorseCode = IsMessageInMorse(message);
            if (!isInMorseCode)
            {
                result = ToMorse(message);
            }
            else
            {
                result = FromMorse(message);
            }

            return result;
        }

        private bool IsMessageInMorse(string message)
        {
            var wholeWordIsInMorse = true;
            var words = message.Trim().Split(LANGUAGE_WORD_SEPARATOR).ToList();
            for (int i = 0; i < words.Count; i++)
            {
                var firstNWordsAreInMorse = i == MINUMUM_WORDS_TO_CHECK_IF_MESSAGE_IS_IN_MORSE - 1 && wholeWordIsInMorse;
                if (firstNWordsAreInMorse)
                {
                    return true;
                }

                var currentWord = words[i].Trim();
                for (int j = 0; j < currentWord.Length; j++)
                {
                    var currentLetter = currentWord[j];
                    var currentLetterIsContainedInMorseCodeAlphabet = MORSE_CODE_CHARACTERS.Contains(currentLetter);
                    if (!currentLetterIsContainedInMorseCodeAlphabet)
                    {
                        return false;
                    }
                    else
                    {
                        wholeWordIsInMorse = currentLetterIsContainedInMorseCodeAlphabet && wholeWordIsInMorse;
                    }
                }
            }

            return true;
        }

        private string ToMorse(string message)
        {
            var builder = new StringBuilder();

            var words = message.ToLower().Split(new char[] { LANGUAGE_WORD_SEPARATOR, MORSE_CODE_CHAR_SEPARATOR }).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    var currentSymbol = currentWord[j];
                    string currentSymbolInMorse = null;
                    if (this.language.Numerals.ContainsKey(currentSymbol))
                    {
                        currentSymbolInMorse = this.language.Numerals[currentSymbol];
                    }
                    else if (this.language.SpecialCharacters.ContainsKey(currentSymbol))
                    {
                        currentSymbolInMorse = this.language.SpecialCharacters[currentSymbol];
                    }
                    else
                    {
                        currentSymbolInMorse = this.language.AlphabetToMorse[currentSymbol];
                    }

                    builder.Append(currentSymbolInMorse);

                    if (j != currentWord.Length - 1)
                    {
                        builder.Append(LANGUAGE_WORD_SEPARATOR);
                    }
                }

                if (i != words.Count - 1)
                {
                    builder.Append(LANGUAGE_WORD_SEPARATOR);
                    builder.Append(MORSE_CODE_CHAR_SEPARATOR);
                    builder.Append(LANGUAGE_WORD_SEPARATOR);
                }
            }

            return builder.ToString().Trim();
        }

        private string FromMorse(string message)
        {
            var builder = new StringBuilder();

            var words = message.Split(MORSE_CODE_CHAR_SEPARATOR).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i].Trim().Split(LANGUAGE_WORD_SEPARATOR);
                for (int j = 0; j < currentWord.Length; j++)
                {
                    var currentSymbol = currentWord[j];
                    string currentSymbolInMorse = null;
                    if (this.language.NumeralsFromMorse.ContainsKey(currentSymbol))
                    {
                        currentSymbolInMorse = (this.language.NumeralsFromMorse[currentSymbol] - CHAR_TO_INT).ToString();
                    }
                    else if (this.language.SpecialCharactersFromMorse.ContainsKey(currentSymbol))
                    {
                        currentSymbolInMorse = this.language.SpecialCharactersFromMorse[currentSymbol].ToString();
                    }
                    else
                    {
                        currentSymbolInMorse = this.language.AlphabetFromMorse[currentSymbol].ToString();
                    }

                    builder.Append(currentSymbolInMorse);
                }

                builder.Append(LANGUAGE_WORD_SEPARATOR);
            }

            return builder.ToString().Trim();
        }
    }
}
