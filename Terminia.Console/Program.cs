using Terminia.Models.Environment;
using Terminia.Utility;

while(true)
{
    var a = Console.ReadKey();
    var color = int.Parse(a.KeyChar.ToString());

    var gameObject = new GameObject(((char)new Random().Next(1, 100)), color);
    var gameMap = new GameMap(50, 20, gameObject);

    Screen.Render(gameMap.ToString("{}"));
}