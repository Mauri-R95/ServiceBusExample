using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Contracts
{
    public class OrderCreated
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
