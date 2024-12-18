using Proxy;

//Without proxy.

Console.WriteLine("Constructing a document");
var document = new Document("complexfile.pdf");
Console.WriteLine("Document construction completed.");
document.DisplayContent();

Console.WriteLine();
Console.WriteLine();

//With proxy
Console.WriteLine("Constructing a document proxy");
var proxy = new DocumentProxy("complexfile.pdf");
Console.WriteLine("Document proxy construction completed.");
proxy.DisplayContent();


Console.WriteLine();
Console.WriteLine();

//With protected proxy
Console.WriteLine("Constructing a protected document proxy");
var protectedproxy = new ProtectedDocumentProxy("complexfile.pdf","Viewer");
Console.WriteLine("protected Document proxy construction completed.");
protectedproxy.DisplayContent();


Console.WriteLine();
Console.WriteLine();

//With protected proxy
Console.WriteLine("Constructing a protected document proxy");
var protectedproxy2 = new ProtectedDocumentProxy("complexfile.pdf", "Outsider");
Console.WriteLine("protected Document proxy construction completed.");
protectedproxy2.DisplayContent();

Console.ReadKey();