using System;

namespace PolynomialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Launch command line interface

            /// Testing
            ///

            Polynomial p = new Polynomial("-13x^9-10x^2-x-1");
            Polynomial p2 = new Polynomial("5x^2+2");

            try
            {
                p2.AddTerm(3, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Polynomial p1 = new Polynomial(new int[] { 1 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Polynomial p1 = new Polynomial("qwfwefwef");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Polynomial p1 = new Polynomial("-32x^2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Polynomial p3 = p * p2;
            Console.WriteLine(p3);
        }
    }
}
