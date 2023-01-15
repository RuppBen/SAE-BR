using System;
    class Student
{
        private string name;
        private string vorname;
        private string email;

        public string Name { get => name; set => name = value;}
        public string Vorname { get => vorname; set => vorname = value;}
        public string Email { get => email; set => email = value;}

        public Student() 
        {
        }
        public Student(string name, string vorname, string email)
        {
            Name = name;
            Vorname = vorname;
            Email = email;   
        }

    public override string ToString()
    {
        return ("Name: "+Name+"\nVorname: "+Vorname+"\nE-mail"+Email);
    }

}