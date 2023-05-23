using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bramki
{
    class Zadanie
    {
        Układ układ;
        Test[] testy;

        public bool Wczytaj(TextReader tr)
        {
            układ = new Układ();
            układ.Wczytaj(tr);
            if (układ.IleWe() == 0) return false;

            int ileT = int.Parse(tr.ReadLine());
            testy = new Test[ileT];
            for (int i = 0; i < ileT; i++)
                testy[i] = new();
            for (int i = 0; i < testy.Length; i++)
                testy[i].Wczytaj(tr, układ.IleWe(), układ.IleWy());
            return true;
        }

        bool SąRówne(bool[] tab1, bool[] tab2)
        {
            for(int i=0; i<tab1.Length; i++)
            {
                if (tab1[i] != tab2[i]) return false;
            }
            return true;
        }

        public bool CzyTestySąZgodne()
        {
            bool zgodne = true;
            for (int i = 0; i < testy.Length && zgodne; i++)
            {
                if (SąRówne(układ.Wyliczanie(testy[i].Wejścia()), testy[i].Wyjścia()))
                {
                    continue;
                }
                zgodne=false;
            }
            return zgodne;
        }
        public (int, int) Rozwiąż()
        {
            if (CzyTestySąZgodne()) return (-1, -1);
            int rodzaj=-1, nrbramki=-1;
            for(int i=0; i<układ.IleBr(); i++)
            {
                for(int j=0; j<3; j++)
                {
                    układ.ZmianaUszkodzenia(i, j);
                    if (CzyTestySąZgodne())
                    {
                        if (rodzaj != -1) return (-2, -2);
                        rodzaj = j;
                        nrbramki = i;
                    }
                }
                układ.ZmianaUszkodzenia(i, 3);
            }
            if(rodzaj == -1) return (-2, -2);
            return (nrbramki, rodzaj);
        }
    }
}
