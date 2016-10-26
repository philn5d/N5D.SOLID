using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Violating
{
    class Person
    {
        private Tuple<string, string>[] _grades = new Tuple<string, string>[] {
            new Tuple<string, string>("English", "A"),
            new Tuple<string, string>("Math", "A"),
            new Tuple<string, string>("Computer Programming", "D")
        };
        public bool IsStudent { get; internal set; }
        public IEnumerable<Person> PeopleToNotify { get; internal set; }
        public string Role { get; internal set; }
        public string Email { get; private set; }
        public string Name { get; private set; }

        internal void NotifyStudentAbsence(Person p)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                string body = string.Format("{0} will be absent from class today.", p.Name);
                MailMessage msg = new MailMessage(this.Email, p.Email, "Notification of Student Absence", body);
                smtp.Send(msg);
            }
        }

        internal void NotifyChildAbsence(Person p)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                string body = string.Format("We have been notified of {0} absence today.", p.Name);
                MailMessage msg = new MailMessage(this.Email, p.Email, "Notification of Student Absence", body);
                smtp.Send(msg);
            }
        }

        internal string GetGrade(string subject)
        {
            return _grades.SingleOrDefault(x => x.Item1 == subject)?.Item2;
        }
    }
}