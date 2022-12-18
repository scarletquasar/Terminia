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
                        if(values[0].Length < 2)
                        {
                            var colors = values[0].Split(" ");
                            return new ColorExpression(values[1], colors[0], colors[1]);
                        }

                        return new ColorExpression(values[1], values[0]);
                    }

                    return new ColorExpression(values[0], "#FFFF");
                })
                .ToList();
        }
    }
}
