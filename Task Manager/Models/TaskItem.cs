using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Models.Enums;

namespace Task_Manager.Models
{
    public class TaskItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; }= string.Empty;
        public DateTime DueDate { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public Priority Priority { get; private set; }
        public Category? Category { get; private set; }

        public TaskItem(string title, DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            Id = Guid.NewGuid();
            Title = title;
            DueDate = dueDate;
            CreatedDate = DateTime.Now;
            Description = string.Empty;
            Priority = Priority.Medium; 
        }

        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(newTitle));
            }
            Title = newTitle;
        }

        public DateTime? CompletedDate { get; private set; }

        public void MarkAsCompleted()
        {
            if(IsCompleted)
            {
                return;
            }

            IsCompleted = true;
            CompletedDate = DateTime.Now;
        }

        public void Reopen()
        {
            if (!IsCompleted)
            {
                return;
            }
            IsCompleted = false;
            CompletedDate = null;
        }

        public void UpdateDescription(string description)
        {
            Description = description ?? string.Empty;
        }

        public bool IsOverdue => !IsCompleted && DueDate.Date < DateTime.Today;

        public void ChangePriority(Priority newPriority)
        {
            Priority = newPriority;
        }

        public void ChangeCategory(Category? category)
        {
            Category = category;
        }
    }
}
