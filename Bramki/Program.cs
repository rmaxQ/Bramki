using System;
using System.IO;
using System.Text;

namespace Bramki
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using StreamReader sr = new("C:/Users/Adam/Desktop/studia/Programowanie Obiektowe 2/Bramki/tekst.txt");
                while (!sr.EndOfStream)
                {
                    Zadanie zadanie = new();

                    if (!zadanie.Wczytaj(sr)) return;
                    (int, int) rozwiązanie = zadanie.Rozwiąż();
                    if (rozwiązanie == (-1, -1)) Console.WriteLine("Układ działa poprawnie");
                    else if (rozwiązanie.Item2 == -2) Console.WriteLine("Nie można zidentyfikować uszkodzenia");
                    else
                    {
                        switch (rozwiązanie.Item2)
                        {
                            case 0:
                                {
                                    Console.WriteLine($"Bramka {rozwiązanie.Item1+1} zwraca zawsze 0");
                                    break;
                                }
                            case 1:
                                {
                                    Console.WriteLine($"Bramka {rozwiązanie.Item1+1} zwraca zawsze 1");
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine($"Bramka {rozwiązanie.Item1+1} zwraca odwrócony wynik");
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Błąd odczytu pliku:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
