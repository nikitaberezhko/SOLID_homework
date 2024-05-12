namespace SOLID_homework;

// Слишком большой интерфейс, возможно нам не нужно реализовывать метод StopGame в нашей игре

// public interface IGame
// {
//     public void StartGame();
//     
//     public void StopGame();
//
//     public void ValidateNumber(NumberValidator validator, int quanityAttemps);
// }

// Разделим интерфейсы

public interface IStartingGame
{
    public void StartGame();
}

public interface IStopableGame
{
    public void StopGame();
}

public interface INumericGame
{
    public void ValidateNumber(NumberValidator validator, int quanityAttemps);
}