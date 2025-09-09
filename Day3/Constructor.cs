using System;
class Sample
{
    public string Name { get; set; }
    public int Age { get; set; }
    public static int Count = 0;
    public Sample()

    {
        Count++;
        Console.WriteLine("The value of count is : " + Count);
        Name = "anvitha";
        Age = 22;
    }
    public Sample(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public Sample(string name)
    {
        Name = name;

    }
    public void Display()
    {
        Console.WriteLine("Name is:" + Name + "Age is:" + Age);
    }
}
class Example
    {


        static void Main()
        {

            Sample s1 = new Sample();
            Sample s2 = new Sample();
            Sample s3 = new Sample();

            s1.Display();
            s2.Display();
            s3.Display();
        }
    }

    
