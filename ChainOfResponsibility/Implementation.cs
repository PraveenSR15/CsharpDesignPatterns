using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility
{
    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLigitation { get; set; }
        public bool ApprovedByManagement { get; set; }

        public Document(string title, DateTimeOffset lastModified, bool approvedByLigitation, bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLigitation = approvedByLigitation;
            ApprovedByManagement = approvedByManagement;
        }
    }

    public interface IHandler<T> where T : class 
    {
        IHandler<T> SetNextHandler(IHandler<T> nextHandler);
        void Handle(T request);
    }

    public class DocumentTitleHandler : IHandler<Document>
    {
        private IHandler<Document> _nextHandler;
        public void Handle(Document document)
        {
            if(document.Title == string.Empty)
            {
                throw new ValidationException(new ValidationResult("Title must not be empty", new List<string> { "Title" }), null, null);
            }
            _nextHandler?.Handle(document);
        }

        public IHandler<Document> SetNextHandler(IHandler<Document> nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
    }

    public class DocumentLastModifiedHandler : IHandler<Document>
    {
        private IHandler<Document> _nextHandler;
        public void Handle(Document document)
        {
            if (document.LastModified < DateTime.UtcNow.AddDays(-30))
            {
                throw new ValidationException(new ValidationResult("Document should be modified in last 30 days", new List<string> { "Last Modified" }), null, null);
            }
            _nextHandler?.Handle(document);
        }

        public IHandler<Document> SetNextHandler(IHandler<Document> nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
    }

    public class DocumentApprovedByLitigationHandler : IHandler<Document>
    {
        private IHandler<Document> _nextHandler;
        public void Handle(Document document)
        {
            if (!document.ApprovedByLigitation)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by Litigation", new List<string> { "Approved by Litigation" }), null, null);
            }
            _nextHandler?.Handle(document);
        }

        public IHandler<Document> SetNextHandler(IHandler<Document> nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
    }

    public class DocumentApprovedByManagementHandler : IHandler<Document>
    {
        private IHandler<Document> _nextHandler;
        public void Handle(Document document)
        {
            if (!document.ApprovedByManagement)
            {
                throw new ValidationException(new ValidationResult("Document must be approved by Management", new List<string> { "Approved by Litigation" }), null, null);
            }
            _nextHandler?.Handle(document);
        }

        public IHandler<Document> SetNextHandler(IHandler<Document> nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
    }
}
