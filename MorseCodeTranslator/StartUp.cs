﻿namespace MorseCodeTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Languages;

    public class StartUp
    {
        public static void Main()
        {
            var input = "Освен това бе забелязал, че магарето, този неразбран от хората четириног мислител, заплашително мърда уши, когато философите говорят глупости.";
            //var input = Console.ReadLine().Trim();

            // Change Bulgarian with English and vice versa 
            var bgTranslator = new Translator(new Bulgarian());
            var fromBgToMorse = bgTranslator.Translate(input, true);
            Console.WriteLine(bgTranslator.LanguageName);
            Console.WriteLine();

            Console.WriteLine(fromBgToMorse);
            Console.WriteLine();

            var fromMorseToBg = bgTranslator.Translate(fromBgToMorse, false);
            Console.WriteLine(fromMorseToBg);
        }
    }
}
