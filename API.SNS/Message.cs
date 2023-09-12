using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SNS
{
    public class Message 
    {
        public string SenderId { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string TextMessage { get; protected set; }
        public MessageType Type { get; protected set; }

        public Message(string senderId, string phoneNumber, string textMessage, MessageType type)
        {
            this.SenderId = senderId;
            this.PhoneNumber = phoneNumber;
            this.TextMessage = textMessage;
            this.Type = type;

        }

    }


}
