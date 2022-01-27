// See https://aka.ms/new-console-template for more information

CustomerManager customerManager = new CustomerManager(new Log4NetLogger());
customerManager.Save();

CustomerManagerTests customerManagerTests = new CustomerManagerTests(); // Logger 'ı çalıştırmadan sadeve save methodunu test ettim. StubLogger fake bi logger Singleton design ' da oluşturuldu. Sürekli instance yaratıp performansı azaltmaması için. Onunla işimiz yok.
customerManagerTests.SaveTest();

Console.ReadLine();


class CustomerManager
{
    private ILogger _logger;
    public CustomerManager(ILogger logger)
    {
        _logger = logger;
    }

    public void Save()
    {
        // business code's
        Console.WriteLine("Saved");
        _logger.Log();
    }
}

interface ILogger
{
    void Log();
}

class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with Log4Net");
    }
}

class NLogLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with NLogger");
    }
}

class StubLogger : ILogger // öylesine log fake
{
    private static StubLogger _stubLogger;
    private static object _lockObject = new object();

    public static StubLogger CreateInstance()
    {
        lock (_lockObject)
        {
            if (_stubLogger == null)
            {
                _stubLogger = new StubLogger();
            }
        }
        return _stubLogger;
    }

    private StubLogger()
    {
       
    }
    public void Log()
    {
        
    }
}

class CustomerManagerTests
{
    public void SaveTest()
    {
        CustomerManager customerManager = new CustomerManager(StubLogger.CreateInstance());
        customerManager.Save();
    }
}
