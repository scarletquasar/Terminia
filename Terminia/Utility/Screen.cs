using Pastel;
using Terminia.Models.Text;

namespace Terminia.Utility
{
    public static class Screen
    {
        public static void Render(
            string text,
            string wrappers = "{}",
            bool replaceFrame = true)
        {
            if(replaceFrame)
            {
                Console.SetCursorPosition(0, 0);
            }

            var parser = new ColorExpressionParser(wrappers);
            var parsed = parser.FromText(text);
            var colored = parsed.Select(expression => expression.Text.Pastel(expression.Color));

            Console.Write(prefix);

            var colorValues = parsed.Select(expression => expression.Text.Pastel(expression.Color)).ToArray();
            var colorText = string.Join("", colorValues);
            Console.Write(colorText);

            Console.WriteLine(suffix);
        }
    }
}
