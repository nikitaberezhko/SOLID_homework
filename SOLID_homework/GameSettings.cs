namespace SOLID_homework;

/// <summary>
/// Настройки игры
/// </summary>
public class GameSettings
{
    public GameSettings(int numberOfAttemps, int startOfRange,int endOfRange)
    {
        NumberOfAttemps = numberOfAttemps;
        StartOfRange = startOfRange;
        EndOfRange = endOfRange;
    }
    
    /// <summary>
    /// Количество попыток
    /// </summary>
    public int NumberOfAttemps { get; set; }
    
    /// <summary>
    /// Начало диапазона отгадывания
    /// </summary>
    public int StartOfRange { get; set; }
    
    /// <summary>
    /// Конец диапазона отгадивания
    /// </summary>
    public int EndOfRange { get; set; }
}