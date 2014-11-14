using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{

    class ExplicitEvent
    {
        // this code in C#...
        
        //public MailHandler NewMail; 

        // ... produces the following code in IL (plus a metadata entry)

        private MailHandler m_NewMail;

        public void add(MailHandler m) { m_NewMail += m; }
        public void remove(MailHandler m) { m_NewMail -= m; }

        // other methods of the type
    }


}






