using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
        public class PaymentService
        {
            public void Pay(string type)
            {
                if (type == "card")
                    Console.WriteLine("Paid by card");
                else if (type == "upi")
                    Console.WriteLine("Paid by UPI");
                else
                    Console.WriteLine("Invalid method");
            }
        //with ocp
    public abstract class PaymentMethod
    {
        public abstract void Pay();
    }

    public class CardPayment : PaymentMethod
    {
        public override void Pay() => Console.WriteLine("Paid by card");
    }

    public class UpiPayment : PaymentMethod
    {
        public override void Pay() => Console.WriteLine("Paid by UPI");
    }

    public class PaymentService
    {
        public void Paying(PaymentMethod method) => method.Pay();
    }


}
}
