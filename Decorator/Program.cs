
using Decorator;

var permisMailService = new OnPermiseMailService();
permisMailService.SendMail("Vanakkam da mapla");

var cloudMailService = new OnCloudMailService();
cloudMailService.SendMail("Theni la irundhu");

var statisticDecorator = new StatisticsDecorator(permisMailService);
statisticDecorator.SendMail("Avasarapattiye Kumaru");

var databaseDecorator = new MessageDatabaseDecorator(cloudMailService);
databaseDecorator.SendMail("Inga enna solludhu ?");
databaseDecorator.SendMail("Jessy Jessy Soldhaa ?");

foreach(var messages in databaseDecorator.Messages)
   Console.WriteLine($"Stored message : {messages}");

Console.ReadKey();