using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Enums;

namespace Domain.Models
{
    public class ReceipeDomain
    {
        public int Receipe_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }

        //public TimeSpan Time_To_Complete { get; set; }
        public TimeSpan Time_To_Complete { get; set; } // should be TimeSpan

        public DateTime Date_Created { get; set; }

        public override string ToString()
        {
            return $"{Receipe_Id} - {Name} - {Description} - {Difficulty} - {Time_To_Complete} - {Date_Created}";
        }
    }
}