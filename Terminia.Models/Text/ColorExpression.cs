namespace Terminia.Models.Text
{
    public class ColorExpression
    {
        public ColorExpression(string text, string fgColor, string bgColor = "#0000")
        {
            Text = text;
            FgColor = fgColor;
            BgColor = bgColor;
        }

        public string Text { get; set; }
        public string FgColor { get; set; }
        public string BgColor { get; set; }
    }
}
