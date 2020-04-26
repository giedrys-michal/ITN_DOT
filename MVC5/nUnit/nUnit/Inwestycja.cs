using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnit
{
    public class Inwestycja
    {
        public double wartoscPrzyszla(double kwotaPoczatkowa, double oprocentowanie, int okresy)
        {
            if (kwotaPoczatkowa < 0)
                throw new ArgumentException();
            else if (okresy < 0)
                throw new ArgumentException();
            else if (kwotaPoczatkowa >= Double.MaxValue
                || oprocentowanie >= Double.MaxValue
                || okresy >= Double.MaxValue)
            {
                throw new OverflowException("Parametry spoza dopuszczalnych zakresów");
            }

            else
                return Math.Round(
                    kwotaPoczatkowa * Math.Pow(1 + oprocentowanie, okresy), 7);
        }

        public double wyliczStope(double kwotaPoczatkowa, double kwotaKoncowa, int okresy)
        {
            if (kwotaPoczatkowa == 0)
                throw new ArithmeticException("Kwota wyjściowa nie może być równa 0");
            else if (kwotaPoczatkowa < 0 || kwotaKoncowa < 0)
                throw new ArithmeticException("Obie kwoty muszą być dodatnie");
            else if (okresy < 0)
                throw new ArithmeticException("Liczba okresów nie może być ujemna");
            else
                return Math.Round(
                    Math.Pow(kwotaKoncowa / kwotaPoczatkowa, 1d / okresy -1), 7);
        }
    }
}
