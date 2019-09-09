using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smartsafe.Models
{
    public class Variable
    {
        public int Id { get; set; }
        public int SignedIn{ get; set; }
    }
}