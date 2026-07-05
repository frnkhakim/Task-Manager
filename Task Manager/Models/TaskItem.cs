using Android.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class TaskItem
    {
        public Guid Id { get;} = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; }= string.Empty;
        public DateTime DueDate { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; }

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

            CreatedDate = DateTime.Now;
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
    }
}
