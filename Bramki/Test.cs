using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bramki
{
    struct Test
    {
        bool[] wejścia;
        bool[] wyjścia;
        public void Wczytaj(TextReader tr, int we, int wy)
        {
            string[] s = tr.ReadLine().ToString().Split();
            wejścia = new bool[we];
            wyjścia = new bool[wy];
            for(int i=0; i<we; i++)
            {
                if (s[i] == "0") wejścia[i] = false;
                else wejścia[i] = true;
            }
            for (int i = 0; i < wy; i++)
            {
                if (s[i+wejścia.Length] == "0") wyjścia[i] = false;
                else wyjścia[i] = true;
            }
        }
        public bool[] Wejścia()
        {
            return wejścia;
        }

        public bool[] Wyjścia()
        {
            return wyjścia;
        }
    }
}
