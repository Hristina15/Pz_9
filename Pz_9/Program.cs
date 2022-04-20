using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pz_9
{
    // Вариант 5 - Минеева Христина и Баранец Юлия
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.start();
        }
    }

    class Student
    {


        public delegate void Handler();
        public event Handler Notify;

        public List<int> ocenki = new List<int>();
        public float sr_usp { get; private set; }

        public void start()
        {
            Notify += dobavit_ocenka;
            Notify.Invoke();
        }

        public void dobavit_ocenka()
        {

            while (true)
            {

                Prepodavatel prepod = new Prepodavatel();

                var summa = 0;
                int ocenka = int.Parse(Console.ReadLine());
                ocenki.Add(ocenka);
                foreach (var ocen in ocenki)
                {
                    summa += ocen;
                }
                sr_usp = summa / ocenki.Count();

                if (prepod.proverit_uspevaemost(sr_usp))
                {
                    break;
                }

            }

        }

    }

    class Prepodavatel
    {
        public bool proverit_uspevaemost(float uspevaemost)
        {
            if (uspevaemost <= 2.4)
            {
                Console.WriteLine("Ты отчислен!");
                return true;
            }
            return false;
        }

    }

}
