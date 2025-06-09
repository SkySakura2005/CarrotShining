using System.Collections.Generic;
using cfg.phone;
using Managers;

namespace Statics
{
    public static class MessageStatics
    {
        public static MessageReaderDB
            messageData = new MessageReaderDB(StaticManager.LoadJson("phone_messagereaderdb"));

        public static List<MessageDB> messages = new List<MessageDB>();
    }
}