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
        public TaskStatus Status { get; private set; }
        private readonly string description;
        private Employer teamLeader;
        private Report reports = new Report();
        public DateTime deadline = new DateTime();
        
        public Task( string description, Employer teamLeader)
        {
            
            this.description = description;
            this.teamLeader = teamLeader;
            Status = TaskStatus.Assigned;

        }
        public void PrintInfo()
        {
            Console.WriteLine($"Описание: {description}, Лидер : {teamLeader}, ");
        }
        public void TaskAdded(int deadline)
        {
            this.deadline = DateTime.Now.AddDays(deadline);
            Status = TaskStatus.InProcess;
        }
    }

}