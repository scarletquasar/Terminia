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
            Console.CursorVisible = false;

            if (replaceFrame)
            {
                Console.SetCursorPosition(0, 0);
            }

            var parser = new ColorExpressionParser(wrappers);
            var parsed = parser.FromText(text);
            var colored = parsed.Select(expression =>
            {
                return expression.Text
                    .Pastel(expression.FgColor)
                    .PastelBg(expression.BgColor);
            });

            var colorText = string.Join("", colored);
            Console.Write(colorText);
        }
    }
}
