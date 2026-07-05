using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class Category
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            }
            Name = name;
        }
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(newName));
            }
            Name = newName;
        }
    }
}
