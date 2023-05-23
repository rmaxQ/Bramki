using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bramki
{
    enum Uszkodzenie
    {
        jeden,
        zero,
        odwrócenie,
        brak
    }
    class BramkaWUkładzie
    {
        internal BramkaWUkładzie[] wejście;
        internal Bramka bramka;
        internal bool? wyjście;
        internal Uszkodzenie? uszkodzenie;
        public BramkaWUkładzie()
        {
        }

        public void Uszkodzenie(int err)
        {
            switch (err)
            {
                case 0:
                    uszkodzenie = Bramki.Uszkodzenie.zero;
                    break;
                case 1:
                    uszkodzenie = Bramki.Uszkodzenie.jeden;
                    break;
                case 2:
                    uszkodzenie = Bramki.Uszkodzenie.odwrócenie;
                    break;
                default:
                    uszkodzenie = null;
                    break;
            }
        }

        public bool Wyjście(params bool[] wejścia)
        {
            
            switch (uszkodzenie)    
            {
                case Bramki.Uszkodzenie.jeden:
                    return true;
                case Bramki.Uszkodzenie.zero:
                    return false;
                case Bramki.Uszkodzenie.odwrócenie:
                    return !bramka.Mapowanie(wejścia);
                default:
                    return bramka.Mapowanie(wejścia);
            }
        }
        public void UstawBramke(Bramka br)
        {
            bramka = br;
            if (br.IleWejść() > 0)
            {
                wejście = new BramkaWUkładzie[br.IleWejść()];
            }
        }

        public bool Wyliczanie()
        {
            if (wyjście != null)
            {
                return (bool)wyjście;  
            }
            bool[] boole;
            boole = new bool[wejście.Length];
            for (int i = 0; i < wejście.Length; i++)
            {
                boole[i] = wejście[i].Wyliczanie();
            }
            wyjście = Wyjście(boole);
            return (bool)wyjście;
        }
    }
}
