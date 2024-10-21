namespace Singleton;

class Program
{
    static void Main(string[] args)
    {
        Logger.Instance.Log("213");
        Logger.Instance.Log("123");
    }

}

//Не потокобезопаская реализация.
public class Logger
{
    private static Logger? _instance;

    public static Logger Instance
    {
        get
        {
            if (_instance is not null)
            {
                return _instance;
            }
            
            _instance = new Logger();
            return _instance;
        }
    }

    private Logger() { }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

//Потокобезопаская реализация через статический конструктор.
public sealed class LoggerSave1
{
    public static LoggerSave1 Instance { get; private set; } = new LoggerSave1();

    // Статический конструктор гарантирует, что экземпляр будет создан только один раз
    static LoggerSave1() { }

    private LoggerSave1() { }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}


