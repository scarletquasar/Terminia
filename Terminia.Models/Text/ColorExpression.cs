namespace Terminia.Models.Text
{
    public class ColorExpression
    {
        public ColorExpression(string text, string color)
        {
            Text = text;
            Color = color;
        }

        public string Text { get; set; }
        public string Color { get; set; }
    }
}
