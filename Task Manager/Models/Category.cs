using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class Category
    {
        [PrimaryKey]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public Category() { }

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
