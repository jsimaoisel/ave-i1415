using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{

    public struct MailMessage
    {
        public String From { get; set; }
        public String To { get; set; }
        public String Message { get; set; }
        public DateTime Time { get; set; }
    }

    public delegate void MailHandler(MailMessage msg);

    public class MailManager
    {
        public event MailHandler NewMail;

        protected void OnNewMail(MailMessage msg)
        {
            if (NewMail != null)
                NewMail(msg);
        }

        public void SimulateNewMail(String From, String To, String Message, DateTime time)
        {
            MailMessage msg = new MailMessage();
            msg.From = From;
            msg.To = To;
            msg.Message = Message;
            msg.Time = time;

            OnNewMail(msg);
        }
    }

    class Program
    {
        static public void Main(string[] args)
        {
            MailManager notifier = new MailManager();
            notifier.NewMail +=
                (mail) =>
                    Console.WriteLine("Received a new email from '{0}' to '{1}' with message '{2}' at time '{3}'",
                    mail.From,
                    mail.To,
                    mail.Message,
                    mail.Time);
            notifier.NewMail +=
                (mail) =>
                    Console.WriteLine("Also received a new email from '{0}' to '{1}' with message '{2}' at time '{3}'",
                    mail.From,
                    mail.To,
                    mail.Message,
                    mail.Time);

            /* simulate the incoming of a new email ...*/
            notifier.SimulateNewMail("jose", "ave-all", "ola mundo", DateTime.Now);
        }
    }
}
