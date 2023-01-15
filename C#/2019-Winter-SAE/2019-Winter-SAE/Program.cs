using System;

namespace _2019_Winter_SAE
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip6 = "2001:0db8:0000:08d3:0000:8a2e:0070:7344";
            string[] buffer = ip6.Split(':');
            char[] buffer2;
            string ergebnis = string.Empty;

            foreach (var item in buffer)
            {
                buffer2 = item.ToCharArray();
                for (int i = 0; i < item.Length; i++)
                {
                    if (buffer2[i] == '0')
                    {
                        buffer2[i] = 'X';
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < buffer2.Length; i++)
                {
                    ergebnis += buffer2[i].ToString();
                }
                ergebnis += ":";
            }
            
            ergebnis = ergebnis.Remove(ergebnis.Length -1);
            System.Console.WriteLine(ergebnis);
        }
    }
}