using Mediator;

TeamChatRoom teamChatRoom = new();

var sanjay = new Lawer("Sanjay");
var prabhu = new Lawer("Prabhu");
var siddharth = new Lawer("Siddharth");
var akil = new AccountManager("Akil");
var praveen = new AccountManager("Praveen");
var pavi = new AccountManager("Pavi");

teamChatRoom.Register(sanjay);
teamChatRoom.Register(prabhu);
teamChatRoom.Register(siddharth);
teamChatRoom.Register(akil);
teamChatRoom.Register(praveen);
teamChatRoom.Register(pavi);

siddharth.Send("Vanakkam da Mapla");
prabhu.Send("Theni la irundhu");
praveen.Send("Irundhutu po.");

praveen.Send("Pavi", "Love you");

praveen.SendTo<Lawer>("Lawers... Assemble..!");

Console.ReadKey();