using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    struct Student
    {
        public int Number { get; set; }
        public String Name { get; set; }
        public double CurrAverage { get; set; }
        public override string ToString()
        {
            return String.Format("[ Number={0} Name={1} CurrAverage={2}]", Number, Name, CurrAverage);
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "jose", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 17.3 });
            list.Add(new Student { Name = "rui", Number = 1123, CurrAverage = 15.1 });
            list.Add(new Student { Name = "pedro", Number = 3222, CurrAverage = 11 });
            list.Add(new Student { Name = "rute", Number = 5543, CurrAverage = 12 });
            list.Add(new Student { Name = "gil", Number = 4332, CurrAverage = 16 });
            list.Add(new Student { Name = "antonio", Number = 9282, CurrAverage = 10 });

            list.Where(s => { Console.WriteLine("Filtering"); return s.CurrAverage > 11 && s.CurrAverage < 16; })
                .Select(s => { Console.WriteLine("Selecting"); return s + ", "; })
                .Skip(2)
                .ToList()
                .ForEach(Console.Write);

            list.Where(s => s.CurrAverage > 12);

            IEnumerable<Student> students =
                from s in list
                where s.CurrAverage > 12
                select s;

            list.Where(s => s.CurrAverage > 12)
                .Select(s => s.Name);

            IEnumerable<String> studentsNames =
                from s in list
                where s.CurrAverage > 12
                select s.Name;

            IEnumerable<Student> seq =
              list.Where(s => s.CurrAverage > 12)
                .OrderBy(s => s.Number)
                .Where(s => s.CurrAverage > 12);

            foreach (Student st in (from s in list
                                    orderby s.Number
                                    where s.CurrAverage > 12
                                    select s))
                Console.WriteLine(st);
        }

    }
}
