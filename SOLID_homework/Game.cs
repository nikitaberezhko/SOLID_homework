using System.ComponentModel.DataAnnotations;

namespace SOLID_homework;


public class Game : IStartingGame, INumericGame
{
    private readonly IReader _reader;
    private readonly IPrinter _printer;
    
    private readonly int _numberOfAttemps;

    private readonly NumberGenerator _generator;
    
    public Game(GameSettings settings,
        IReader reader,
        IPrinter printer)
    {
        _reader = reader;
        _printer = printer;
        _numberOfAttemps = settings.NumberOfAttemps;
        _generator = new EvenNumberGenerator(settings.StartOfRange, settings.EndOfRange);
        
        _printer.Print($"-- -- Удайте число от {settings.StartOfRange} до {settings.EndOfRange} -- --");
    }

    public void StartGame()
    {
        while (true)
        {
            Console.WriteLine($"Игра началась =)");
            var secretNumber = _generator.Generate();
            var validator = new NumberValidator(secretNumber);
        
            ValidateNumber(validator, _numberOfAttemps);
        }
    }

    public void ValidateNumber(NumberValidator validator, int quanityAttemps)
    {
        var i = 0;
        while (i < _numberOfAttemps)
        {
            _printer.Print($"Осталось попыток: {_numberOfAttemps - i}, введите число");
            
            var result = validator.ValidateNumber(_reader.Read());
            
            if (result == 0)
            {
                _printer.Print("Вы угадали!!!\n");
                return;
            }
            if(result == -1)
                _printer.Print("Недолет");
            if(result == 1)
                _printer.Print("Перелет");
            i++;
        }
    }
}


public interface INumberValidator
{
    public int ValidateNumber(int number);
}

/// <summary>
/// Проверяет угадал ли пользователь или дает подсказку
/// 1 — перелет,
/// (-1) — недолет,
/// 0 — совпадение
/// </summary>
public class NumberValidator
{
    private int _secretNumber;

    public NumberValidator(int secretNumber)
    {
        _secretNumber = secretNumber;
    }
    public int ValidateNumber(int number)
    {
        if (number > _secretNumber) return 1;
        if (number < _secretNumber) return -1;
        return 0;
    }
}



/// <summary>
/// Генератор чисел в заданном диапазоне
/// </summary>
public class NumberGenerator
{
    private Random _random;
    private int _startOfRange;
    private int _endOfRange;
    

    public NumberGenerator(int startOfRange, int endOfRange)
    {
        _startOfRange = startOfRange;
        _endOfRange = endOfRange;
        _random = new Random();
    }

    public virtual int Generate()
    {
        return _random.Next(_startOfRange, _endOfRange);
    }
}


/// <summary>
/// Генератор четных чисел
/// </summary>
public class EvenNumberGenerator : NumberGenerator
{
    private Random _random;
    private int _startOfRange;
    private int _endOfRange;
    
    public EvenNumberGenerator(int startOfRange, int endOfRange) 
        : base(startOfRange, endOfRange)
    {
        _startOfRange = startOfRange;
        _endOfRange = endOfRange;
        _random = new Random();
    }
    
    public override int Generate()
    {
        var number = 1;
        while (number % 2 != 0)
        {
            number = _random.Next(_startOfRange, _endOfRange);
        }

        return number;
    }
}