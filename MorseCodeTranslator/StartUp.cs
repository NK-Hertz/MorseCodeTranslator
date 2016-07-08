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
            var bgTranslator = new Translator(new Bulgarian());
            var fromBgToMorse = bgTranslator.Translate(input);
            Console.WriteLine(bgTranslator.LanguageName);
            Console.WriteLine();

            Console.WriteLine(fromBgToMorse);
            Console.WriteLine();

            var fromMorseToBg = bgTranslator.Translate(fromBgToMorse);
            Console.WriteLine(fromMorseToBg);
        }
    }
}
