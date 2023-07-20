using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class Appointment : BaseClass
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public void Add() 
        {
            
        }

        public void Update() 
        { 

        }

        public void Delete()
        {

        }
    }
}
