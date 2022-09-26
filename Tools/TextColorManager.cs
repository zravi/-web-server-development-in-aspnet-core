namespace MovieCharactersEFCodeFirst.Tools
{
    public static class TextColorManager
    {
        private const ConsoleColor DefaultForegroundColor = ConsoleColor.DarkYellow;

        public static void ResetColor()
        {
            Console.ForegroundColor = DefaultForegroundColor;
        }
        
        public static void SetColor(ConsoleColor newColor)
        {
            Console.ForegroundColor = newColor;
        }

        public static void WriteInColor(string text, ConsoleColor newColor)
        {
            Console.ForegroundColor = newColor;
            Console.WriteLine(text);
            ResetColor();
        }

        public static void Warning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            ResetColor();
        }
    }
}