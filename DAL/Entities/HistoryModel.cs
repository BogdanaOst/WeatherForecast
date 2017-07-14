using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class HistoryModel:IEntity
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public double DayTemp { get; set; }
        public string Icon { get; set; }
        public int NumOfDaysRequested { get; set; }
    }
}
