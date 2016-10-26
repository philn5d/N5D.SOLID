using System;

namespace Conforming
{
    internal class AbsenceNotifier : Notifier
    {
        internal override void SendNotification<T>(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}