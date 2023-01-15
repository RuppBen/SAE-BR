using System;

namespace Schwein
{
    class Schwein
    {
        private double gewicht = 1.4;
        private int lebensalter = 0;
        private string name = string.Empty;
        public double Gewicht { get => gewicht; set => gewicht = value; }
        public Schwein() 
        {
            name = "Gertrund"; //weitere möglichkeit für standart Variablen
        }
        public Schwein(double gewicht, int lebensalter, string name)
        {
            this.gewicht = gewicht;
            this.lebensalter = lebensalter;
            this.name = name;
        }
        public string Benennen(string name) 
        {
            this.name = name;   //this.name bezieht such auf die privat deklarierte variable name
            return "Das Schwein hat einen Namen bekommen und ist glücklich.";
        }
        public string GibName()
        {
            return name;
        }
    }
}