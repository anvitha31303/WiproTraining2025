using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //without dip
    //High-level modules should depend on abstractions.
    internal class DIP
    {
        public class OrderManager
        {
            private EmailService email = new EmailService(); // ❌ tightly coupled

            public void ConfirmOrder() => email.Send("Order confirmed");
        }

        public class EmailService
        {
            public void Send(string msg) => Console.WriteLine("Email: " + msg);
        }


        //with dip
        public interface INotifier
            {
                void Send(string message);
            }

            public class EmailService : INotifier
            {
                public void Send(string message) => Console.WriteLine("Email: " + message);
            }

            public class OrderManager
            {
                private readonly INotifier _notifier;

                public OrderManager(INotifier notifier)
                {
                    _notifier = notifier;
                }

                public void ConfirmOrder() => _notifier.Send("Order confirmed");
            }

        }
    