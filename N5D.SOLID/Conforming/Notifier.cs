using System;

namespace Conforming
{
    public abstract class Notifier
    {
        internal abstract void SendNotification<T>(string emailAddress);
    }
}