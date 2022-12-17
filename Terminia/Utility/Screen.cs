using Terminia.Models.Text;

namespace Terminia.Utility
{
    public static class Screen
    {
        public static void Render(
            string text,
            string wrappers = "{}",
            string prefix = "\n",
            string suffix = "\n",
            bool replaceFrame = true,
            ConsoleColor defaultColor = ConsoleColor.White)
        {
            if(replaceFrame)
            {
                Console.Clear();
            }

            var parser = new ColorExpressionParser(wrappers);
            var parsed = parser.FromText(text);

            Console.Write(prefix);

            parsed.ForEach(value =>
            {
                Console.ForegroundColor = value.Color;
                Console.Write(value.Text);
                Console.ForegroundColor = defaultColor;
            });

            Console.WriteLine(suffix);
        }
    }
}
