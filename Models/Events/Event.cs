using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartsafe.Models
{
    public class Event
    {
        public int Id { get; set; }

         [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Criticite { get; set; }  
        public string Description{ get; set; }
    }
}