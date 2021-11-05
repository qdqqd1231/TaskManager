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
            employers.Add(new Employer("Александр", "Кузнецов"));
            employers.Add(new Employer("Ксения", "Макарова"));
            employers.Add(new Employer("Карим", "Муллоянов"));
            employers.Add(new Employer("Сергей", "Гинсбург"));
            employers.Add(new Employer("Рустэм", "Садыков"));
            employers.Add(new Employer("Анастасия", "Тимофеева"));
            employers.Add(new Employer("Данис", "Вильданов"));
            employers.Add(new Employer("Владислав", "Куликов"));



            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Описание первой задачи", teamLeader));
            tasks.Add(new Task("Описание Второй задачи", teamLeader));
            tasks.Add(new Task("Описание Третей задачи", teamLeader));
            tasks.Add(new Task("Описание Четвертой задачи", teamLeader));
            tasks.Add(new Task("Описание Пятой задачи", teamLeader));
            tasks.Add(new Task("Описание Шестой задачи", teamLeader));
            tasks.Add(new Task("Описание Седьмой задачи", teamLeader));
            tasks.Add(new Task("Описание Восьмой задачи", teamLeader));
            tasks.Add(new Task("Описание Девятой задачи", teamLeader));
            tasks.Add(new Task("Описание Десятой задачи", teamLeader));




            Console.WriteLine("\t\t\t\t\tЗдравствуйте вас приветствует первыя версия Task Manager");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Поиск проекта");
            Thread.Sleep(350);
            Console.Write('.');
            Thread.Sleep(350);
            Console.Write('.');
            Thread.Sleep(350);
            Console.WriteLine('.');
            Thread.Sleep(500);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Проект  найден !");
            Console.ResetColor();
            Console.WriteLine($"Заказчик :{Boss.name} {Boss.surname}");


            Project project = new Project("Название проекта", "описание проекта", teamLeader, tasks);

            Console.Write("Боcс назначьте дэдлайн(количество дней)-->");
            int projectdeadline;
            while (!int.TryParse(Console.ReadLine(), out projectdeadline) || projectdeadline < 0)
            {
                Console.WriteLine("неверно ввели число дней");
            }
            project.DeadlineProject(projectdeadline);
            project.Status = ProjectStatus.Project;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Сколько дней можно решать задачи?");
            int deadLine;
            while (!int.TryParse(Console.ReadLine(), out deadLine) || deadLine < 0)
            {
                Console.WriteLine("Неверный ввод!Повторите");
            }


            if (project.Status.Equals(ProjectStatus.Project))
            {
                Employer.GiveTask(tasks, employers, deadLine);
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Все задачи переданы");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            while (employers.Count > 0)
            {
                Console.WriteLine("Выберите номер сотрудника,который сдает отчет:");

                for (int i = 0; i < employers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {employers[i].name} {employers[i].surname}");
                }
                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > employers.Count)
                {
                    Console.WriteLine("Неверный ввод,повторите ввод!");
                }
                Report report = Report.TakeReport(employers[index - 1]);
                Employer.SendTask(employers[index - 1]);

                Console.WriteLine("Проверка прошла успешна?да/нет");
                bool input = Console.ReadLine().ToLower().Equals("да");
                if (input)
                {
                    Console.WriteLine("Работник сдал эту задачу!");
                    employers.Remove(employers[index - 1]);
                    report = null;
                }
                else
                {
                    Console.WriteLine("Задача отправлена на доработку!");
                    report = null;
                }
            }
            project.CloseProject();
        }




    }
            
}
