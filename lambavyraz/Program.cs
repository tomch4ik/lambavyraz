using static System.Net.Mime.MediaTypeNames;

namespace lambavyraz
{
    internal class Program
    {
        delegate bool Finder(string text, string word);
        static void Main(string[] args)
        {
            string[] texts =
            {
                "Сегодня 20 ноября 2024 года вышел сталкер 2!",
            };

            string wordToFind = "сталкер";
            Finder TextChecker = (text, word) =>
                !string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(word) &&
                text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
            foreach (string text in texts)
            {
                bool result = TextChecker(text, wordToFind);
                Console.WriteLine($"Текст: \"{text}\" содержит слово \"{wordToFind}\"? {result}");
            }
        }
    }
}
