using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnit.Wykonywalny
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: pytanie o pozostałe parametry
            // TODO: obsługa wyjątków

            var inw = new Inwestycja();

            try
            {
                Console.Write("Podaj kwotę: ");
                double kwota = Double.Parse(Console.ReadLine());

                Console.Write("Podaj oprocentowanie: ");
                double oprocentowanie = Double.Parse(Console.ReadLine());

                Console.Write("Podaj liczbę okresów: ");
                double okresy = Double.Parse(Console.ReadLine());

                if (kwota < 0)
                    throw new ArgumentException();
                else if (okresy < 0)
                    throw new ArgumentException();
                else if (kwota >= Double.MaxValue
                    || oprocentowanie >= Double.MaxValue
                    || okresy >= Double.MaxValue)
                {
                    throw new OverflowException("Parametry spoza dopuszczalnych zakresów");
                }

                Console.WriteLine(inw.wartoscPrzyszla(kwota, oprocentowanie, (int)okresy));
                Console.ReadKey();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
