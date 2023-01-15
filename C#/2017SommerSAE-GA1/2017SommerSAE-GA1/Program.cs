using System;

namespace _2017SommerSAE_GA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(berechnePruefziffer(21050170, 12345678));
        }
        static int berechnePruefziffer(int blz, int kontoNr)
        {
            int pruefziffer;
            
            while(blz >= 97)
            {
                blz = blz -97;
            }
            kontoNr = kontoNr * 1000000;
            kontoNr = kontoNr + 131400;
            while(kontoNr >= 88529281)
            {
                kontoNr = kontoNr - 88529281;
            }
            while(kontoNr >= 97)
            {
                kontoNr = kontoNr -97;
            }
            pruefziffer = blz*62+kontoNr;
            while(pruefziffer >= 97)
            {
                pruefziffer= pruefziffer-97;
            }
            pruefziffer = 98 - pruefziffer;
            return pruefziffer;
        }
    }
}
