namespace Mediator
{
    //public abstract class ChatRoom
    //{
    //    public abstract void Register(TeamMember teamMember);
    //    public abstract void Send(string from, string message);
    //}
    public interface IChatRoom
    {
        void Register(TeamMember teamMember);
        void Send(string from, string message);
        void Send(string from, string to, string message);
        void SendTo<T>(string from, string message) where T : TeamMember;
    }
    public abstract class TeamMember 
    {
        private IChatRoom? _chatRoom;
        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }
        internal void SetChatRoom(IChatRoom chatRoom) 
        {
            _chatRoom = chatRoom;
        }
        public void Send(string message)
        {
            _chatRoom?.Send(Name,message);
        }
        public void Send(string to, string message)
        {
            _chatRoom?.Send(Name, to, message);
        }
        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom?.SendTo<T>(Name, message);
        }
        public virtual void Receive(string from,string message)
        {
            Console.WriteLine($"Message {from} to {Name} : {message}");
        }
    }

    public class Lawer : TeamMember
    {
        public Lawer(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawer)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> _teamMembers = new();

        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatRoom(this);
            if(!_teamMembers.ContainsKey(teamMember.Name))
                _teamMembers.Add(teamMember.Name, teamMember);
        }

        public void Send(string from, string message)
        {
            foreach(var member in _teamMembers.Values)
                member.Receive(from, message);
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = _teamMembers[to];
            teamMember?.Receive(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach(var member in _teamMembers.Values.OfType<T>())
            {
                member.Receive(from, message);
            }
        }
    }
}
