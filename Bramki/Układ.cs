using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bramki
{
    class Układ
    {
        BramkaWUkładzie[] bramki;
        BramkaWUkładzie[] wejścia;
        BramkaWUkładzie[] wyjścia;
        public void Wczytaj(TextReader tr)
        {
            string[] linia = tr.ReadLine().ToString().Split(' ');
            wejścia = new BramkaWUkładzie[int.Parse(linia[0])];
            bramki = new BramkaWUkładzie[int.Parse(linia[1])];
            wyjścia = new BramkaWUkładzie[int.Parse(linia[2])];
            TworzenieRamek(ref wejścia);
            TworzenieRamek(ref bramki);
            TworzenieRamek(ref wyjścia);
            if (wejścia.Length != 0)
            {
                for (int i = 0; i < bramki.Length; i++)
                {
                    linia = tr.ReadLine().ToString().Split(' ');
                    Bramka bramka;
                    switch (linia[0])
                    {
                        case "o":
                            bramka = new Or();
                            break;
                        case "a":
                            bramka = new And();
                            break;
                        case "x":
                            bramka = new Xor();
                            break;
                        case "n":
                            bramka = new Not();
                            break;
                        default:
                            bramka = new Not();
                            break;
                    }
                    bramki[i].UstawBramke(bramka);
                    for(int j=1; j<linia.Length; j++)
                    {
                        if (linia[j][0] == 'i')
                        {
                            bramki[i].wejście[j - 1] = wejścia[linia[j][1] - '0' - 1];
                        }
                        else
                        {
                            bramki[i].wejście[j - 1] = bramki[linia[j][1] - '0' - 1];
                        }
                    }
                }
                linia = tr.ReadLine().ToString().Split(' ');
                for (int i = 0; i < linia.Length; i++)
                {
                    wyjścia[i] = bramki[int.Parse(linia[i]) - 1];
                }
            }
        }

        void Reset()
        {
            for (int i = 0; i < bramki.Length; i++)
            {
                bramki[i].wyjście = null;
            }
        }

        public void ZmianaUszkodzenia(int indeks, int uszkodzenie)
        {
            bramki[indeks].Uszkodzenie(uszkodzenie);
        }

        void WypełnienieWejść(bool[] input)
        {
            for (int i = 0; i < wejścia.Length; i++)
            {
                wejścia[i].wyjście = input[i];
            }
        }

        public bool[] Wyliczanie(bool[] input)
        {
            Reset();
            WypełnienieWejść(input);
            bool[] output;
            output = new bool[IleWy()];
            for(int i=0; i<wyjścia.Length; i++)
            {
                output[i] = wyjścia[i].Wyliczanie();
            }
            return output;
        }

        public int IleWy()
        {
            return wyjścia.Length;
        }

        public int IleWe()
        {
            return wejścia.Length;
        }

        public int IleBr()
        {
            return bramki.Length;
        }

        private static void TworzenieRamek(ref BramkaWUkładzie[] bramki)
        {
            for(int i=0; i<bramki.Length; i++)
            {
                bramki[i] = new BramkaWUkładzie();
            }
        }
    }
}
