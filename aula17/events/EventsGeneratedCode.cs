using System;

namespace events
{

    class EventsGeneratedCode
    {
        // this code in C#...

        //public event MailHandler NewMail; 

        // ... produces the following code in IL (plus a metadata entry)

        private MailHandler m_NewMail;

        public void add(MailHandler m) { m_NewMail += m; }
        public void remove(MailHandler m) { m_NewMail -= m; }

        // other methods of the type
    }


}