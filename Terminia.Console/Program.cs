using Terminia.Models.Environment;
using Terminia.Utility;

var color = "#64a822";

var gameObject = new GameObject('.', color);
var gameMap = new GameMap(32, 16, gameObject);
var gameActor = new GameActor(gameMap, '@', "#ffff");

await gameActor.Initialize();

while (true)
{
    var rendered = gameMap.ToString("{}");
    Screen.Render(rendered);

    var control = Console.ReadKey(true);

    switch(control.Key)
    {
        case ConsoleKey.W:
            await gameActor.Move(0, -1);
            break;

        case ConsoleKey.A:
            await gameActor.Move(-1, 0);
            break;

        case ConsoleKey.S:
            await gameActor.Move(0, 1);
            break;

        case ConsoleKey.D:
            await gameActor.Move(1, 0);
            break;
    }
}