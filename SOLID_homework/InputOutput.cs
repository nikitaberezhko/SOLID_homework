namespace SOLID_homework;

public interface IPrinter
{
    public void Print(string text);
}

public interface IReader
{
    public int Read();
}

/// <summary>
/// Выводит сообщения на консоль
/// </summary>
public class ConsolePrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}

/// <summary>
/// Считывает вводимые пользователем числа
/// </summary>
public class ConsoleReader : IReader
{
    public int Read()
    {
        if (int.TryParse(Console.ReadLine(), out var number))
            return number;
        return -1;
    }
}
