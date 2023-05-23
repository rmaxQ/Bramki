using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bramki
{
    abstract class Bramka
    {
        protected int liczba_wejść;
        public abstract bool Mapowanie(params bool[] wejścia);
        public int IleWejść()
        {
            return liczba_wejść;
        }
    }

    class And : Bramka
    {
        public And() {
            liczba_wejść = 2;
        }

        public override bool Mapowanie(params bool[] wejścia)
        {
            return wejścia[0] && wejścia[1];
        }
    }
    class Or : Bramka
    {
        public Or()
        {
            liczba_wejść = 2;
        }
        public override bool Mapowanie(params bool[] wejścia)
        {
            return wejścia[0] || wejścia[1];
        }
    }
    class Xor : Bramka
    {
        public Xor()
        {
            liczba_wejść = 2;
        }
        public override bool Mapowanie(params bool[] wejścia)
        {
            return (!wejścia[0]&&wejścia[1]) || (!wejścia[1]&&wejścia[0]);
        }
    }

    class Not : Bramka
    {
        public Not()
        {
            liczba_wejść = 1;
        }
        public override bool Mapowanie(params bool[] wejścia)
        {
            return !wejścia[0];
        }
    }
}
