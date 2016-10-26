namespace Conforming
{
    class Person
    {
        string _email;
        public void Notify(Notifier notifier)
        {
            notifier.SendNotification<Parent>(_email);
        }
    }
}