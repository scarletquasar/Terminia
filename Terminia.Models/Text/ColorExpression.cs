namespace Terminia.Models.Text
{
    public class ColorExpression
    {
        public ColorExpression(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }

        public ColorExpression(string text, int color)
        { 
            if(color > 15 || color < 0)
            {
                color = 15;
            }

            Text = text;
            Color = (ConsoleColor)color;
        }

        public string Text { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
