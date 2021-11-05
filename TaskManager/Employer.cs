using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Employer
    {
        public string name { get; set; }
        private string surname { get; }
        private Task currentTask;
        public Employer(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public static void GiveTask(List<Task> tasks, List<Employer> employers, int deadline)
        {
            List<Task> tmpTasks = new List<Task>(tasks.Count);
            tmpTasks.AddRange(tasks);
            int counterTasks = 0;
            int countTasks = tasks.Count;
            for (int i = 0; i < employers.Count; i++)
            {
                int retryCounter = 0;
                for (int j = 0; j < tmpTasks.Count; j++)
                {

                    Console.WriteLine($"Задач осталось для выбора : {countTasks - counterTasks - retryCounter - 1}");
                    Console.WriteLine($"Задача {counterTasks + 1}");
                    tasks[j].PrintInfo();
                    Console.WriteLine($"Согласен ли сотрудник {employers[i].name} {employers[i].surname} выполнять ее?да/нет");
                    string input = Console.ReadLine().ToLower();
                    if (!input.Equals("нет") || j == tmpTasks.Count - 1)
                    {
                        if (tasks.Count - 1 == j)
                        {
                            Console.WriteLine("Задачи закончились придется выдать вам последнюю!");
                        }
                        employers[i].currentTask = tmpTasks[j];
                        employers[i].currentTask.TaskAdded(deadline);
                        tmpTasks.Remove(tmpTasks[j]);
                        Console.WriteLine("Задача успешно передана!Нажмите enter для продолжения");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        retryCounter++;
                    }
                }
                counterTasks++;
            }
        }
    }
}
