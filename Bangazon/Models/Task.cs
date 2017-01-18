using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class Task
    {
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Status OrderStatus { get; set; }
        public DateTime CompletedOn { get; set; }
    }

    public enum Status
    {
        ToDo,
        InProgress,
        Complete
    }
}