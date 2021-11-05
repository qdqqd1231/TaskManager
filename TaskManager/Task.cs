using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum TaskStatus
    {
        Assigned,
        InProcess,
        OnCheck,
        Complited
    }
    class Task
    {
        public TaskStatus status { get; private set; }
        private readonly string description;
        private Employer teamLeader;
        
        public DateTime deadline = new DateTime();
        
        public Task( string description, Employer teamLeader)
        {
            
            this.description = description;
            this.teamLeader = teamLeader;
            status = TaskStatus.Assigned;

        }
        public void PrintInfo()
        {
            Console.WriteLine($"Описание: {description}, Лидер : {teamLeader.name}");
        }
        public void TaskDeadlineAndStastusInProcrss(int deadline)
        {
            this.deadline = DateTime.Now.AddDays(deadline);
            status = TaskStatus.InProcess;
        }
        public static void GiveOnCheck(Task task)
        {
            if (task != null && task.status == TaskStatus.InProcess)
            {
                task.status = TaskStatus.OnCheck;
            }
        }
    }

}