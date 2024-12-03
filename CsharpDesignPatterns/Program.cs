using Singleton;

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if(instance1 == instance2 && instance2 == Logger.Instance)
    Console.WriteLine("Same Instances");

instance1.Log($"This message is from {nameof(instance1)}");
instance2.Log($"This message is from {nameof(instance2)}");
Logger.Instance.Log($"This message is from {nameof(Logger.Instance)}");

Console.ReadLine();