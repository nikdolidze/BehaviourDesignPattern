using System;
using System.Collections.Generic;
using System.Linq;
/*
The intent is to define an object, the mediator, that encapsulate how a set of objects interact.
Thhe intetn of this pattern is to define a object -the mediator- that  encapsulates how a set of objects interacts. it does that by forcing objects to communicate
via that mediator

Abstract chatroom class is mediator, thid defines an interface for communicating with Collegue objects
TeamChatRoom is concreate mediator.it knows and mainteins collegue and it implements cooperative behaviour by coordinating collegue objects.

    Use cases:
    1.When a set of object communicate in well-define but complex ways.
    2.when because an object refers  to an communicates with many other objects the object is difficult to reuse
    3.when behavopir that's distributed between several classes should be customizable without a lot of sublacces

    Pattern ConseQuences
    1.it limits subclassing
    2.it decouples collegues
    3.it simplifies object protocols
    
*/

namespace Mediator
{
    //public abstract class ChatRoom
    //{
    //    public abstract void Registger(TeamMember teamMember);
    //    public abstract void Send(string from, string message);
    //}
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IChatRoom
    {
        void Registger(TeamMember teamMember);
        void Send(string from, string message);
        void Send(string from,string to,string message);
        void Send<T>(string from,string message)where T : TeamMember;
    }
    /// <summary>
    /// Colllegue
    /// </summary>
    public abstract class TeamMember
    {
        private IChatRoom _chatRoom;
        public string Name { get; set; }
        public TeamMember(string name)
        {
            this.Name = name;
        }
        internal void SerChatRoom(IChatRoom chatRoom)
        {
            this._chatRoom = chatRoom;
        }
        public void Send(string message) => _chatRoom.Send(Name, message);

        public void Send(string to,string message)=> _chatRoom.Send(Name,to,message);

        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom.Send<T>(Name, message);
        }

        public virtual void Recieve(string from,string message)
        {
            Console.WriteLine($"Message {from} to {Name} : {message}");
        }
    }
    /// <summary>
    /// Concreate Collegure
    /// </summary>
    public class Loyer : TeamMember
    {
        public Loyer(string name) : base(name)
        {
        }
        public override void Recieve(string from, string message)
        {
            Console.WriteLine($"{nameof(Loyer)}   {Name} Recieved");
            base.Recieve(from, message);    
        }
    }
    /// <summary>
    /// Concreate Collegure
    /// </summary>
    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }
        public override void Recieve(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} name : {Name} Recieved");
            base.Recieve(from, message);
        }
    }

    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();
        public void Registger(TeamMember teamMember)
        {
            teamMember.SerChatRoom(this);
            if(!teamMembers.ContainsKey(teamMember.Name))   
                teamMembers.Add(teamMember.Name, teamMember); 
        }

        public void Send(string from, string message)
        {
            foreach (var teamMember in teamMembers.Values)
            {
                teamMember.Recieve(from, message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
           teamMember.Recieve(from, message); 
        }

        public void Send<T>(string from, string message) where T : TeamMember
        {
            foreach (var item in teamMembers.Values.OfType<T>())
            {
                item.Recieve(from,message);
            }
        }
    }
}
