using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFool
{
    class Chat
    {
        public List<String> Messages { get; private set; }
        
        public Chat()
        {
            this.Messages = new List<string>();
        }

        public void PostMessage(String message)
        {
            if (message != null || message != "\0")
                this.Messages.Add(message);
        }
    }
}
