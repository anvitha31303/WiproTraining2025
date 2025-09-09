using System;
namespace OopsExample
{
    public struct Booksss
    {
        public string Title;
        public string Author;

        public decimal Price;
        public short Year;

    }
    enum DaysOfWeek
    {
        Mon,Tues,Wed,Thurs,Fri,Sat
    }
     enum Status
    {

        Pending,
        Approved,
        Rejected
    }

    public class BookEx
    {
        public static void Main()
        {


            DaysOfWeek d1 = DaysOfWeek.Tues;
            Booksss myBook = new Booksss();

            myBook.Title = "CSharp";
            myBook.Author = "ABC";
            myBook.Price = 4545.00M;
            myBook.Year = 2017;

            Console.WriteLine(myBook.Title + " " + myBook.Author + " " + myBook.Price + " " + myBook.Year);

            if (d1 == DaysOfWeek.Mon || d1 == DaysOfWeek.Tues)
            {
                Console.WriteLine("either it is monday or tuesday");
            }

            else { Console.WriteLine("either it is monday or tuesday"); }

            switch (d1)
            {
                case DaysOfWeek.Mon:
                    Console.WriteLine("It's Monday");
                    break;
                case DaysOfWeek.Tues:
                    Console.WriteLine("It's Tuesday");
                    break;
                case DaysOfWeek.Wed:
                    Console.WriteLine("It's Wednesday");
                    break;
                default:
                    Console.WriteLine("It's Weekend");
                    break;



            }
            Status s = Status.Pending;
            string statusstring = s.ToString();
            foreach (Status st in Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine(st);
            }  
            

        }
    }


    }
