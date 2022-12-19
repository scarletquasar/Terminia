namespace Terminia.Models.Environment
{
    public class GameActor : GameObject
    {
        private readonly GameMap _gameMap;

        private int _currentXPos;
        private int _currentYPos;
        private bool _initialized = false;

        public GameActor(
            GameMap gameMap,
            char indicator, 
            string color, 
            int initialXPos = default, 
            int initialYPos = default) : base(indicator, color)
        {
            _gameMap = gameMap;
            _currentXPos = initialXPos;
            _currentYPos = initialYPos;
        }

        public async Task Initialize()
        {
            if (!_initialized)
            {
                await _gameMap.Overlap(_currentXPos, _currentYPos, this);
                _initialized = true;
                return;
            }

            throw new InvalidOperationException("Object already initialized");
        }

        public async Task Move(int x, int y)
        {
            await _gameMap.Subpose(_currentXPos, _currentYPos);

            _currentXPos += x;
            _currentYPos += y;

            if(_currentXPos < 0) _currentXPos = 0;
            if(_currentYPos < 0) _currentYPos = 0;
            if (_currentXPos > _gameMap.MaxX - 1) _currentXPos = _gameMap.MaxX - 1;
            if (_currentYPos > _gameMap.MaxY - 1) _currentYPos = _gameMap.MaxY - 1;

            await _gameMap.Overlap(_currentXPos, _currentYPos, this);
        }
    }
}
