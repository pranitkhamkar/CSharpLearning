using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program

    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter the Number :");
            num = int.Parse(Console.ReadLine());

            if (num % 3 == 0 && num % 5 == 0)

            {
                Console.WriteLine("Entered Number is Divisible by 3 & 5 also");
                Console.WriteLine("Pranit Khamkar ");
            }
            else if
            (num % 3 == 0 && (num < 0 || num > 0))
            {
                Console.WriteLine("Entered Number is Divisible by Only 3");
                Console.WriteLine("Pranit");

            }

            else if (num % 5 == 0 && (num < 0 || num > 0))
            {
                Console.WriteLine("Entered Number is Divisible by Only 5");
                Console.WriteLine("Khamkar");
            }


            Console.ReadLine();
        }
    }
}

