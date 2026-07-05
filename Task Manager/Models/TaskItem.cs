using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class TaskItem
    {
        public Guid Id { get;} = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            }

            Id = Guid.NewGuid();

            Title = title;

            DueDate = dueDate;

            Description = string.Empty;

            IsCompleted = false;
        }
    }
}
