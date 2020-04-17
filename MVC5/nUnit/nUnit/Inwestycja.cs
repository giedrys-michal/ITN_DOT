using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnit
{
    public class Inwestycja
    {
        public double wartoscPrzyszla(double kwotaPoczatkowa, double oprocentowanie)
        {
            if (kwotaPoczatkowa < 0)
                throw new ArgumentException();
            return Math.Round(kwotaPoczatkowa * (1 + oprocentowanie), 7);
        }

        public double wyliczStope(double kwotaPoczatkowa, double kwotaKoncowa)
        {
            return Math.Round((kwotaKoncowa / kwotaPoczatkowa -1), 7);
            //throw new NotImplementedException();
        }
    }
}
