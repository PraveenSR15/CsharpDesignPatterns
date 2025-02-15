﻿namespace Decorator
{
    public interface IMailService
    {
        public bool SendMail(string message);
    }
    public class OnPermiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message : {message} sent via {nameof(OnPermiseMailService)}.");
            return true;
        }
    }
    public class OnCloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message : {message} sent via {nameof(OnCloudMailService)}.");
            return true;
        }
    }

    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        protected MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}.");
            return base.SendMail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> Messages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                Messages.Add(message);
                return true;
            }
            return false;
        }
    }
}
