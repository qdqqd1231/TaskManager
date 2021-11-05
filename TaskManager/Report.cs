using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    
    class Report
    {

        private string textReport;
        private DateTime delivery = new DateTime();
        private Employer employer;
        public DateTime DateDelivery
        {
            get { return delivery; }
        }
        public Report(string text, Employer employer)
        {
            textReport = text;
            this.employer = employer;
        }

        public static Report TakeReport(Employer employer)
        {
            Console.WriteLine("Какой текст отчета у сотрудника?");
            string text = Console.ReadLine();

            return new Report(text, employer);

        }

        
    }
}
