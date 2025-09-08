using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class OnlineShoppingEx
    {

 // Without SOLID Principles

// This class does everything by itself: save, print, payment, notify.
//  Violates SRP, OCP, DIP
public class BadOrderSystem
    {
        public int OrderId { get; set; }
        public List<string> Items = new List<string>();

        public void SaveOrder()
        {
            //  Saves data itself – no separation of concerns
            Console.WriteLine("Saving order directly in this class.");
        }

        public void PrintInvoice()
        {
            // invoice logic
            Console.WriteLine("Printing invoice directly in this class.");
        }

        public void ProcessPayment(string type, double amount)
        {
            // Payment logic is tightly coupled and hard to extend
            if (type == "card")
                Console.WriteLine("Processing credit card payment...");
            else if (type == "upi")
                Console.WriteLine("Processing UPI payment...");
            else
                Console.WriteLine("Invalid payment type");
        }

        public void NotifyCustomer()
        {
            // Directly sending notification from same class
            Console.WriteLine("Sending email directly from Order class.");
        }
    }

   

    // With SOLID Principles

    //  SRP: Order only holds data
    public class Order
    {
        public int OrderId { get; set; }
        public List<string> Items = new List<string>();
    }

    //  SRP: Separate class for saving order
    public class OrderSaver
    {
        public void Save(Order order)
        {
            Console.WriteLine("Saving order via separate repository.");
        }
    }

    //  OCP: New invoice types can be added without modifying existing ones
    public abstract class Invoice
    {
        public abstract void Print(Order order);
    }

    public class PdfInvoice : Invoice
    {
        public override void Print(Order order)
        {
            Console.WriteLine("PDF Invoice printed.");
        }
    }

    public class HtmlInvoice : Invoice
    {
        public override void Print(Order order)
        {
            Console.WriteLine("HTML Invoice printed.");
        }
    }

    //  LSP: Derived payment classes can substitute base class
    public abstract class Payment
    {
        public abstract void Pay(double amount);
    }

    public class CardPayment : Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine("Card payment of ₹" + amount);
        }
    }

    public class UpiPayment : Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine("UPI payment of ₹" + amount);
        }
    }

    //  ISP: Interface only for what is needed (email only)
    public interface IEmailSender
    {
        void SendEmail(string message);
    }

    public class EmailSender : IEmailSender
    {
        public void SendEmail(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }

    // DIP: Depends on interface, not on concrete EmailSender
    public class OrderService
    {
        private readonly IEmailSender _emailSender;

        public OrderService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void CompleteOrder(Order order)
        {
            Console.WriteLine("Completing order via service.");
            _emailSender.SendEmail("Order completed successfully.");
        }
    }


    class Program
    {
        static void Main()
        {
            Console.WriteLine("= WITHOUT SOLID =");
            var badOrder = new BadOrderSystem { OrderId = 1 };
            badOrder.Items.Add("Book");
            badOrder.SaveOrder();              // All logic in one class
            badOrder.PrintInvoice();           // Hardcoded logic
            badOrder.ProcessPayment("upi", 300); // Cannot extend without editing
            badOrder.NotifyCustomer();         // No abstraction

            Console.WriteLine("\n= WITH SOLID =");
            var order = new Order { OrderId = 2 };
            order.Items.Add("Pen");

            var saver = new OrderSaver();
            saver.Save(order);                 //  Separate class handles saving

            Invoice invoice = new HtmlInvoice();
            invoice.Print(order);              // Easy to extend: just swap class

            Payment payment = new CardPayment();
            payment.Pay(500);                  // Replaceable payment type

            IEmailSender email = new EmailSender();
            var service = new OrderService(email); // Injected via interface
            service.CompleteOrder(order);      // Loose coupling
        }
    }

}
}
