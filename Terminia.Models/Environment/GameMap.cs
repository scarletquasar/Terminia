using System.Text;

namespace Terminia.Models.Environment
{
    public class GameMap
    {
        private readonly GameObject[][] _map;
        private readonly GameObject _defaultGameObject;

        public int MaxX { get; }
        public int MaxY { get; }

        public GameMap(int sizeX, int sizeY, GameObject defaultGameObject)
        {
            MaxX = sizeX;
            MaxY = sizeY;

            var lines = Enumerable.Repeat(defaultGameObject, sizeX).ToArray();
            var columns = Enumerable.Repeat(0, sizeY).Select(_ => lines.ToArray()).ToList();

            _map = columns.ToArray();
            _defaultGameObject = defaultGameObject;
        }

        public async Task Overlap(int x, int y, GameObject gameObject)
        {
            await Task.Factory.StartNew(() =>
            {
                if (x < 0) x = 0;
                if (y < 0) y = 0;

                var passingY = y > _map.Length - 1;
                var passingX = _map.Length - 1 > y && x > _map[y].Length - 1;

                var notPassingMaxBounds = !passingY && !passingX;

                if (notPassingMaxBounds)
                {
                    _map[y][x] = gameObject;
                    return;
                }
            });
        }

        public async Task Subpose(int x, int y)
        {
            await Task.Factory.StartNew(() =>
            {
                if (x < 0) x = 0;
                if (y < 0) y = 0;

                var passingY = y > _map.Length - 1;
                var passingX = _map.Length - 1 > y && x > _map[y].Length - 1;

                var notPassingMaxBounds = !passingY && !passingX;

                if (notPassingMaxBounds)
                {
                    _map[y][x] = _defaultGameObject;
                }
            });
        }

        public string ToString(string wrappers)
        {
            var resultBuilder = new StringBuilder();

            foreach (var line in _map)
            {
                foreach(var item in line)
                {
                    resultBuilder.Append($"{wrappers[0]}{item.Color}{wrappers[1]}{item.Indicator}");
                }

                resultBuilder.Append(System.Environment.NewLine);
            }

            return resultBuilder.ToString();
        }
    }
}
