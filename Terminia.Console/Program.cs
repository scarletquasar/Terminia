using Terminia.Models.Environment;
using Terminia.Utility;

var color = "#64a822";

var gameObject = new GameObject('.', color);
var gameMap = new GameMap(32, 16, gameObject);
var gameActor = new GameActor(gameMap, '@', "#ffff");

await gameActor.Initialize();

render();

while (true)
{
    var control = Console.ReadKey(true);

    switch(control.Key)
    {
        case ConsoleKey.W:
            await gameActor.Move(0, -1);
            render();
            break;

        case ConsoleKey.A:
            await gameActor.Move(-1, 0);
            render();
            break;

        case ConsoleKey.S:
            await gameActor.Move(0, 1);
            render();
            break;

        case ConsoleKey.D:
            await gameActor.Move(1, 0);
            render();
            break;
    }
}

void render()
{
    var rendered = gameMap.ToString("{}");
    Screen.Render(rendered);
}