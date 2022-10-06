namespace ClientRegistrator
{
    internal class NameConverter
    {

        Dictionary<string, string> words = new Dictionary<string, string>() {
            {"а", "a" },
            { "б", "b" },
            { "в", "v" },
            { "г", "g" },
            { "д", "d" },
            { "е", "e" },
            { "ё", "yo" },
            { "ж", "zh" },
            { "з", "z" },
            { "и", "i" },
            { "й", "i" },
            { "к", "k" },
            { "л", "l" },
            { "м", "m" },
            { "н", "n" },
            { "о", "o" },
            { "п", "p" },
            { "р", "r" },
            { "с", "s" },
            { "т", "t" },
            { "у", "u" },
            { "ф", "f" },
            { "х", "h" },
            { "ц", "c" },
            { "ч", "ch" },
            { "ш", "sh" },
            { "щ", "sch" },
            { "ъ", "j" },
            { "ы", "i" },
            { "ь", "" },
            { "э", "e" },
            { "ю", "yu" },
            { "я", "ya" },
        };

        public String convertFullNameToAccount(String firstname, String lastname)
        {
            return CyrillicToLatin(firstname) + "_" + CyrillicToLatin(lastname).Trim();
        }

        private String CyrillicToLatin(String cyrillic)
        {
            return String.Join("", cyrillic.ToCharArray().Select(symol => words.GetValueOrDefault(symol.ToString().ToLower(), symol.ToString().ToLower())));
        }
    }
}
