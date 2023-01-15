using System;
using System.Collections;
using System.Collections.Generic;

    class Suche
    {
        public Suche()
        {
        }
        public bool Result(ArrayList myList, string suche)
        {
            bool lol = false;
            foreach (var item in myList)
            {
                if (suche == item.ToString())
                    lol = true;
            }
            return lol;
        }
    }