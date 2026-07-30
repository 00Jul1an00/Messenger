using System;
using System.Collections.Generic;
using System.Text;

namespace MessagesService
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
