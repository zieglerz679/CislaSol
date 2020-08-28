using Cisla;
using PrvocislaCmd.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrvocislaCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Vítejte v ultra super kalkulačce prvočísel!", Console.ForegroundColor);
            //Console.WriteLine("===========================================\n", Console.ForegroundColor);

            //Console.ForegroundColor = ConsoleColor.White;

            //int maximum = LoadNumber();
            int maximum;
            if (!int.TryParse(args[0], out maximum))
            {
                Console.WriteLine("ERROR: Chybný parametr");
                return;
            }

            int[] polePrvocisel = new int[1];
            try
            {
                polePrvocisel = Prvocisla.VratPrvocislaDo(maximum);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            Array.Sort(polePrvocisel);

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\nVýsledek:", Console.ForegroundColor);

            //Console.ForegroundColor = ConsoleColor.White;

            int maxDigitCount = ($"{polePrvocisel[polePrvocisel.Length - 1]}").Length;

            int tmp = 1;
            int pocetNaRadek = Settings.Default.PocetNaRadek;

            StringBuilder sb = new StringBuilder(10000);
            //Console.Write("\t");
            for (int i = 0; i < polePrvocisel.Length; i++)
            {
                string formattedValue = $"{polePrvocisel[i]}".PadLeft(maxDigitCount, ' ');

                if ((tmp % pocetNaRadek == 0) || (i+1 == polePrvocisel.Length))
                    //Console.Write($"{formattedValue}\n\t");
                    sb.Append($"{formattedValue}\n");
                else
                    //Console.Write($"{formattedValue}, ");
                    sb.Append($"{formattedValue}, ");

                tmp++;
            }

            //Console.ReadKey();

            if (string.IsNullOrWhiteSpace(args[1]))
            {
                Console.Error.WriteLine("Chybný název souboru! Název souboru je prázný nebo obsahuje pouze bílé znaky.");
                return;
            }

            try
            {
                File.WriteAllText(args[1], sb.ToString());
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        static int LoadNumber()
        {
            int x;
            while (true)
            {
                Console.Write("Zadej maximum: ");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Musíte zadat kladné celé číslo, které je maximálně {Int32.MaxValue}\n", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return x;
        }
    }
}
