namespace Proxy
{
    public interface IDocument
    {
        public void DisplayContent();
    }
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine($"Document is loading please wait.");
            Thread.Sleep(1000);

            Title = "Large Document";
            AuthorId = 1;
            Content = "Huge content of around 1000 pages.";
            LastAccessed = DateTimeOffset.Now;
        }

        public void DisplayContent()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }
    public class DocumentProxy : IDocument
    {
        private string _fileName;
        private Lazy<Document> _document;
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }
        public void DisplayContent()
        {
            _document.Value.DisplayContent();
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private string _fileName;
        private string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(fileName);
        }

        public void DisplayContent()
        {
            Console.WriteLine("Entering Display Mode.");
            Console.WriteLine("Checking access before showing content.");

            if (_userRole != "Viewer")
                throw new UnauthorizedAccessException();
            
            _documentProxy.DisplayContent();
            
            Console.WriteLine("Exiting Display Mode.");
        }
    }
}
