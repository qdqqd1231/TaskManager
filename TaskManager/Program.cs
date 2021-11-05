using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            Employee Boss = new Employee("Богдан", "Шанькин");
            Employer teamLeader = new Employer("Дина", "Латыпова");
            List<Employer> employers = new List<Employer>(10);
            employers.Add(new Employer("Никита", "Макурин"));
            employers.Add(new Employer("Регина", "Зиннатуллина"));
            employers.Add(new Employer("Рамис", "Гарипов"));
            employers.Add(new Employer("Александр","Кузнецов"));
            employers.Add(new Employer("Ксения", "Макарова"));
            employers.Add(new Employer("Карим", "Муллоянов"));
            employers.Add(new Employer("Сергей", "Гинсбург"));
            employers.Add(new Employer("Рустэм", "Садыков"));
            employers.Add(new Employer("Анастасия", "Тимофеева"));
            employers.Add(new Employer("Данис", "Вильданов"));
            employers.Add(new Employer("Владислав", "Куликов"));



            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Описание первой задачи", teamLeader));




            Console.WriteLine("\t\t\t\t\tЗдравствуйте вас приветствует первыя версия Task Manager");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Поиск проекта.");
            Thread.Sleep(300);
            Console.Write('.');
            Thread.Sleep(300);
            Console.Write('.');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задача найдена !");
            Console.ResetColor();
            Console.WriteLine($"Заказчик :{Boss.name} {Boss.surname}");
            Project project = new Project("Название проекта", "описание проекта", teamLeader, tasks);
            
            Console.Write("Бос назначьте дэдлайн(количество дней)-->");
            int projectdeadline;
            while (!int.TryParse(Console.ReadLine(), out projectdeadline)||projectdeadline>0)
            {
                Console.WriteLine("неверно ввели число дней");
            }
            project.DeadlineProject(projectdeadline);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Сколько дней можно решать задачи?");
            int deadLine;
            while (!int.TryParse(Console.ReadLine(), out deadLine) || deadLine < 0)
            {
                Console.WriteLine("Неверный ввод!Повторите");
            }


            if (project.Status.Equals("Project"))
            {
                Employer.GiveTask(tasks, employers, deadLine);
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Все задачи переданы");                    
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите <сдать>,если завершили задачу, ппосле проверки проверка прошла успешно наберите <закрыть>");
                string input = Console.ReadLine().ToLower();
                if (input.Equals("сдать"))
                {

                }
                else if (input.Equals("закрыть"))
                {

                }
            }




        }
    }
}
