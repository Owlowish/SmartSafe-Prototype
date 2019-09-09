using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartsafe.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserNumber { get; set; }
        public string Password {get; set;}

        public string FirstName {get; set;}
        public string FamilyName{get;set;}
    }
}