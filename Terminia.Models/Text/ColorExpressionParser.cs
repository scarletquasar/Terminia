namespace Terminia.Models.Text
{
    public class ColorExpressionParser
    {
        private readonly string _wrappers;

        public ColorExpressionParser(string wrappers)
        {
            _wrappers = wrappers;
        }

        public List<ColorExpression> FromText(string text)
        {
            ReadOnlySpan<char> wrappers = _wrappers;

            var wrapperStart = wrappers[0];
            var wrapperEnd = wrappers[1];

            var nodes = text.Split(wrapperStart);

            return nodes
                .SkipWhile(string.IsNullOrWhiteSpace)
                .Select(node =>
                {
                    var values = node.Split(wrapperEnd);

                    if (values.Length > 1)
                    {
                        _ = int.TryParse(values[0], out var colorNumber);
                        var textContent = values[1];

                        return new ColorExpression(textContent, colorNumber);
                    }

                    return new ColorExpression(values[0], 15);
                })
                .ToList();
        }
    }
}
