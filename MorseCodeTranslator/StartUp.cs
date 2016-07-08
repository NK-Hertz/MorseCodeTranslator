namespace MorseCodeTranslator
{
    using System;
    using Languages;

    public class StartUp
    {
        public static void Main()
        {
            var input = "Освен това бе забелязал, че магарето, този неразбран от хората четириног мислител, заплашително мърда уши, когато философите говорят глупости.";
            //var input = "I say the whole world must learn of our peaceful ways...by force!";
            //var input = Console.ReadLine().Trim();

            // Change Bulgarian with English and vice versa 
            var myTranslator = new Translator(new Bulgarian());
            var fromLanguageToMorse = myTranslator.Translate(input);
            Console.WriteLine(myTranslator.LanguageName);
            Console.WriteLine();

            Console.WriteLine(fromLanguageToMorse);
            Console.WriteLine();

            var fromMorseToLanguage = myTranslator.Translate(fromLanguageToMorse);
            Console.WriteLine(fromMorseToLanguage);
            Console.WriteLine();

            var sos = "... --- ...";
            var translatedSos = myTranslator.Translate(sos);
            Console.WriteLine("{0} -> {1}", sos, translatedSos);
        }
    }
}
