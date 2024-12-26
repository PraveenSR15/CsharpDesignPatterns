namespace TemplateMethod
{
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding the Server.");
        }
        public abstract void AuthenticateToServer();
        public string ParseHTMLMailBody(string identifier)
        {
            Console.WriteLine("Parsing HTML body.");
            return $"This is the body of the mail with id {identifier}.";
        }
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing the mail body.");
            FindServer();
            AuthenticateToServer();
            return ParseHTMLMailBody(identifier);
        }
    }

    public class ExchangeMailParser : MailParser
    {

        public override void AuthenticateToServer()
        {
            Console.WriteLine($"Connecting to Exchange.");
        }
    }
    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache.");
        }
    }
    public class EudoraMailParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora Server through a custom algorithm.");
        }
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora.");
        }
    }
}
