using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum StatusOfProject
    {
        Project,
        Execution,
        Closed
    }
    class Project
    {
        public StatusOfProject Status { get; set; }
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
            
            Status = StatusOfProject.Project;
        }
        public void DeadlineProject(int deadline)
        {
            this.projectDeadline = DateTime.Now.AddDays(deadline);
            Status = StatusOfProject.Execution;
        }
    }
}
