using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public DateTime DueDate { get; set; }
        public bool isIsCompleted { get; set; }
    }
}
