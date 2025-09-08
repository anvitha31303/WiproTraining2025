using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IShoppingDevice
    {
        void ScanCard();
        void PrintReceipt();
        void SendOTP();
    }

    public class POSDevice : IShoppingDevice
    {
        public void ScanCard() => Console.WriteLine("Card scanned");
        public void PrintReceipt() => Console.WriteLine("Receipt printed");
        public void SendOTP() => throw new NotImplementedException(); // ❌
    }
    public interface ICardScanner
    {
        void ScanCard();
    }

    public interface IReceiptPrinter
    {
        void PrintReceipt();
    }

    public class POSDevice : ICardScanner, IReceiptPrinter
    {
        public void ScanCard() => Console.WriteLine("Card scanned");
        public void PrintReceipt() => Console.WriteLine("Receipt printed");
    }

}
