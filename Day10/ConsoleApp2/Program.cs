using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    //    public sealed class Singleton
    //    {
    //        private static Singleton sample = null;
    //        private Singleton() { }
    //        public static Singleton Sample
    //        {
    //            get
    //            {
    //                if (sample == null)
    //                    sample = new Singleton();
    //                return sample;
    //            }
    //        }
    //        public void ShowMessage(string msg)
    //        {
    //            Console.WriteLine(msg);
    //        }
    //    }
    //    class Program
    //    {

    //        static void Main(string[] args)
    //        {
    //            Singleton obj = Singleton.Sample;
    //            obj.ShowMessage("hello");
    //        }
    //    }

    //}


    //second topic-----> Adaptee: Legacy class with incompatible interface
    //    public class LegacyPrinter
    //    {
    //        public void PrintDocument()
    //        {
    //            Console.WriteLine("Printing document using LegacyPrinter...");
    //        }
    //    }

    //    // Target Interface: What the client expects
    //    public interface IPrinter
    //    {
    //        void Print();
    //    }

    //    // Adapter: Converts LegacyPrinter to IPrinter
    //    public class PrinterAdapter : IPrinter
    //    {
    //        private readonly LegacyPrinter _legacyPrinter;

    //        public PrinterAdapter(LegacyPrinter legacyPrinter)
    //        {
    //            _legacyPrinter = legacyPrinter;
    //        }

    //        public void Print()
    //        {
    //            _legacyPrinter.PrintDocument(); // Translate call
    //        }
    //    }

    //    // Client Code
    //    class Program
    //    {
    //        static void Main()
    //        {
    //            IPrinter printer = new PrinterAdapter(new LegacyPrinter());
    //            printer.Print(); // Works like a charm!
    //        }
    //    }
    //}


    // Handler interface
    public abstract class Approver
    {
        protected Approver _next;

        public void SetNext(Approver next) => _next = next;

        public abstract void ProcessRequest(PurchaseRequest request);
    }
    public class Manager : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 10000)
                Console.WriteLine("Manager approved request for ₹" + request.Amount);
            else
                _next?.ProcessRequest(request);
        }
    }

    public class Director : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 50000)
                Console.WriteLine("Director approved request for ₹" + request.Amount);
            else
                _next?.ProcessRequest(request);
        }
    }
    public class VicePresident : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 100000)
                Console.WriteLine("Vice President approved request for ₹" + request.Amount);
            else
                Console.WriteLine("Request for ₹" + request.Amount + " requires board approval.");
        }
    }

    public class PurchaseRequest
    {
        public double Amount { get; set; }

        public PurchaseRequest(double amount)
        {
            Amount = amount;
        }
    }
    class Program
    {
        static void Main()
        {
            Approver manager = new Manager();
            Approver director = new Director();
            Approver vp = new VicePresident();

            manager.SetNext(director);
            director.SetNext(vp);

            var requests = new[]
            {
            new PurchaseRequest(5000),
            new PurchaseRequest(30000),
            new PurchaseRequest(75000),
            new PurchaseRequest(150000)
        };

            foreach (var request in requests)
            {
                manager.ProcessRequest(request);
            }
        }
    }
}