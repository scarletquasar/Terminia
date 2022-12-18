using Terminia.Models.Environment;
using Terminia.Utility;

while(true)
{
    var a = Console.ReadKey(true);
    var color = "#64a822";

    var gameObject = new GameObject(a.KeyChar, color);
    var gameMap = new GameMap(50, 20, gameObject);
    var rendered = gameMap.ToString("{}");
    Screen.Render(rendered);
}