using ChainOfResponsibility;

var document = new Document("SR", DateTime.UtcNow.AddDays(-10), true, true);
var invalidDocument = new Document("SR", DateTime.UtcNow.AddDays(-10), false, true);

var chainOfHandlers = new DocumentTitleHandler();
chainOfHandlers
    .SetNextHandler(new DocumentLastModifiedHandler())
    .SetNextHandler(new DocumentApprovedByLitigationHandler())
    .SetNextHandler(new DocumentApprovedByManagementHandler());

try
{
    Console.WriteLine("Valid Document");
    chainOfHandlers.Handle(document);
    Console.WriteLine("Valid Document - is Valid");

    Console.WriteLine("Invalid Document");
    chainOfHandlers.Handle(invalidDocument);
    Console.WriteLine("Invalid Document - is Valid");
}
catch(Exception message)
{
    Console.WriteLine(message.Message);
}

Console.ReadKey();