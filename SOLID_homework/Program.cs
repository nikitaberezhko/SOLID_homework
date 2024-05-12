namespace SOLID_homework;

class Program
{
    static void Main()
    {
        var gameSettings = new GameSettings(
            numberOfAttemps: 3,
            startOfRange: 0,
            endOfRange: 10);

        var game = new Game(gameSettings, 
            new ConsoleReader(), 
            new ConsolePrinter());
        
        game.StartGame();
    }
}