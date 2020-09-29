using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        //private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;

        public MessagePublisher(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        //public MessagePublisher(IQueueClient queueClient)
        //{
        //    _queueClient = queueClient;
        //}

        public Task Publish<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            //return _queueClient.SendAsync(message);
            message.UserProperties["MessageType"] = typeof(T).Name;
            return _topicClient.SendAsync(message);
        }
       

        public Task Publish(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            message.UserProperties["MessageType"] = "Raw";
            //return _queueClient.SendAsync(message);
            return _topicClient.SendAsync(message);
        }
    }
}
