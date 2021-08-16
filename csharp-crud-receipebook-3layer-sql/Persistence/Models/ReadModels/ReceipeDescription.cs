using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models.ReadModels
{
    public class ReceipeDescription
    {
        public int Receipe_Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Receipe_Id} - {Description}";
        }
    }
}