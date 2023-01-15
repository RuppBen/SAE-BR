using System;
using System.Collections.Generic;   //must be used for list lib
using System.Collections;           //must be used for ArrayList

namespace _13._01Übung
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student student1 = new Student("Maier", "Jürgen", "jm@web.de");

            //Array for the Student class

            /*
            Student[] students = new Student[50];
            students[0] = student1;
            students[1] = new Student("Weber", "Hans", "hansweber@gmx.de");

            for (int i = 0; i < 2; i++)
            {
                System.Console.WriteLine(students[i].ToString());
                System.Console.WriteLine();
            }
            */

            /*
            List<Student>students = new List<Student>(3);
            students.Add(student1);
            students.Add(new Student("Weber", "Hans", "hansweber@gmx.de"));
            students.Add(new Student("Uhl", "Maximilian","muhl@haloweb.de"));
            students.Add(new Student("Weinfuhrter", "Loris", "wl@hallowelt.de"));

            foreach (Student item in students)
            {
                System.Console.WriteLine(item);
                System.Console.WriteLine();
            }
            */
            
            // 20.01.2021 ArrayList

            Suche nSearch = new Suche();
            string suche;

            ArrayList myList = new ArrayList();
            myList.Add("das ist ein String");
            myList.Add(42);
            myList.Add(3.14);
            myList.Add(DateTime.Now);
            myList.Add(true);

            foreach (var item in myList)    //var = abdeckung aller Typen
            {
                if (item is DateTime)     //Filter mit IF abfrage
                System.Console.WriteLine(item.ToString()); //ToString kann für standart Datentypen wekgelassen werden
            }
            myList.RemoveAt(1);
            myList.Clear();

            myList.Add("Geutner");
            myList.Add("Pieck");
            myList.Add("Hohnstein");
            myList.Add("Geier");
            myList.Add("Yalcin");
            myList.Add("Uhl");
            myList.Add("Musovic");
            
            myList.Sort();

            foreach (var item in myList)
            {
                System.Console.WriteLine(item);
            }

            System.Console.Write("Suche: ");
            suche = Console.ReadLine();

            System.Console.WriteLine(nSearch.Result(myList, suche));

            //Testing of Loop
            /*
            foreach (var item in myList)
            {
                if (suche == item.ToString())
                    break;
                else
                    System.Console.WriteLine("LOL");
            }
            */
        }
    }
}