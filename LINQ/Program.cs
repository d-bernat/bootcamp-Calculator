using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    delegate bool Predicate(Student student);
    class LINQ
    {
        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student(){ ID = 1, Name = "Dusan Bernat", Age = 50 },
                new Student(){ ID = 2, Name = "Samuel Bernat", Age = 18 },
                new Student(){ ID = 2, Name = "Karolina Brave", Age = 27 },
                new Student(){ ID = 2, Name = "Barbora Dorow", Age = 39 }
            };

            foreach (var s in Student.where(students, delegate (Student student) { return student.Age > 20 && student.Age < 40; }))
                Console.WriteLine(s?.ToString());

            foreach (var s in Student.where(students, (Student student) => student.Age > 20 && student.Age < 40))
                Console.WriteLine(s?.ToString());

            foreach (var s in students.Where(student => student.Age > 20 && student.Age < 40))
                Console.WriteLine(s.ToString());

            foreach (var s in from student in students where student.Age > 20 && student.Age < 40 select student)
                Console.WriteLine(s.ToString());

            Predicate<Student> predicate = student => student.Age > 20 && student.Age < 40;
            Func<Student, int> getStudentAge = s => s.Age;
            foreach (var s in from student in students where predicate(student) select student)
                Console.WriteLine(getStudentAge(s));

            Action<Student> write = s => Console.WriteLine(s);
            foreach (var s in from student in students where student.Age > 18 && student.Age < 40 orderby student.Name descending select student)
                write(s);

            foreach (var s in students) s.Dispose();

            using (Student s = new Student())
            {

            }

            Console.Read();
        }

    }

    class Student : IDisposable
    {
        private bool disposed;
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + " Name: " + Name + " Age: " + Age;
        }


        public static Student[] where(Student[] students, Predicate predicate)
        {
            Student[] std = new Student[students.Length];
            var i = 0;
            foreach (var s in students)
            {
                if (predicate(s))
                {
                    std[i++] = s;
                }
            }

            return std;
        }

        public void Dispose()
        {
            cleanUp(true);
            GC.SuppressFinalize(this);
        }

        ~Student()
        {
            cleanUp(false);   
        }

        private void cleanUp(bool dispose)
        {
            if (dispose)
            {
                Console.WriteLine("Disposed");
            }
            else
            {
                Console.Beep();
            }
            disposed = true;
        }
        
    }
}
