using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator(); // ara bulucu
            Teacher teacher = new Teacher(mediator);
            Student student1 = new Student(mediator) { Name = "Orçun"};
            Student student2 = new Student(mediator) { Name = "Deniz"};

            mediator.Students = new List<Student>();
            mediator.Teacher = teacher;
            mediator.Students.Add(student1);
            mediator.Students.Add(student2);

            teacher.SendNewImageUrl("slide1.jpg");

            teacher.RecieveQuestion("Is it true ? ", student2);


            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}",student.Name,question);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0} {1}", student.Name, answer);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url); // bütün öğrencilere bu image yi gönderebildim.
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }
        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieved image : {0}" , url ,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
