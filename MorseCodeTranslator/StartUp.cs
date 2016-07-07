namespace MorseCodeTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Languages;

    public class StartUp
    {
        public static void Main()
        {
            //var input = "Каменица и цаца"; 
            var input = Console.ReadLine().Trim();

            var bgTranslator = new Translator(new Bulgarian());
            var fromBgToMorse = bgTranslator.Translate(input, true);
            Console.WriteLine(bgTranslator.LanguageName);
            Console.WriteLine(fromBgToMorse);

            var fromMorseToBg = bgTranslator.Translate(fromBgToMorse, false);
            Console.WriteLine(fromMorseToBg);
        }
    }
}
