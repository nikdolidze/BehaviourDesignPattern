using System;

namespace Observer3
{
    public interface ISubject
    {
        event Action<User3> UserChanged;

        void UpdateUserAge(int age);
    }
}