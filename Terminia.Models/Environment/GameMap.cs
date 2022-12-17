using System.Text;
using Terminia.Models.Optimization;

namespace Terminia.Models.Environment
{
    public class GameMap
    {
        private readonly GameObject[][] _map;
        private readonly GameObject _defaultGameObject;

        public GameMap(int sizeX, int sizeY, GameObject defaultGameObject)
        {
            _map = new GameObject[sizeX][];
            _defaultGameObject = defaultGameObject;

            ArrayOptimizations.Fill(_map, defaultGameObject);
        }

        public void Put(int x, int y, GameObject gameObject)
        {
            _map[x][y] = gameObject;
        }

        public void Remove(int x, int y)
        {
            _map[x][y] = _defaultGameObject;
        }

        public string ToString(string wrappers)
        {
            var resultBuilder = new StringBuilder();

            foreach (var line in _map)
            {
                foreach(var character in line)
                {
                    resultBuilder.Append($"{wrappers[0]}{character.Color}{wrappers[1]}{character.Indicator}");
                }
            }

            return resultBuilder.ToString();
        }
    }
}
