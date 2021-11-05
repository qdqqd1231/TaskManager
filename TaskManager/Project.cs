using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum ProjectStatus
    {
        Project,
        Perfomance,
        Closed
    }
    class Project
    {
        public ProjectStatus Status { get; set; }
        public string description { get;  }
        public string name { get; }
        public Employer employer { get; private set; }
        private List<Task> tasks = new List<Task>();
        private DateTime projectDeadline = new DateTime();
        public Project(string name, string description, Employer teamLeader, List<Task> tasks)
        {
            this.name = name;
            this.description = description;
            employer = teamLeader;
            this.tasks = tasks;
            
            Status = ProjectStatus.Project;
        }
        public void DeadlineProject(int projectDeadline)
        {
            this.projectDeadline = DateTime.Now.AddDays(projectDeadline);
            Status = ProjectStatus.Perfomance;
        }

        public void GiveProgect(List<Employee> employees)
        {
            bool projectIsAvaliable = true;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] == null)
                {
                    Console.WriteLine("Проект нельзя сформировать,некоторые работники не получили задачи!");
                    projectIsAvaliable = false;
                }
            }
            if (projectIsAvaliable)
            {
                this.Status = ProjectStatus.Perfomance;
                Console.WriteLine("Проект принят на исполнение");
            }
        }
        public void CloseProject()
        {
            if (Status == ProjectStatus.Perfomance && this != null)
            {
                Status = ProjectStatus.Closed;
            }
            if (projectDeadline < DateTime.Now)
            {
                Console.WriteLine("Проект закрыт не в срок!Все без премии!");
            }
            else
            {
                Console.WriteLine("Проект успели в дедлайн закрыть!Ура!!!");
            }
        }
    }
}
