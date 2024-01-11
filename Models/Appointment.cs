using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Aplicatie.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public required string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
