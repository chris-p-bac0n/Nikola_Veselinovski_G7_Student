using System;
using HabitTracker.Enums;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker
{
    public class Habit
    {
        public string Title { get; set; }
        public Group Group { get; set; }
        public Difficulty Difficulty { get; set; }
        public HabitType Type { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Habit(string title, Group group, Difficulty difficulty, HabitType type)
        {
            Title = title;
            Group = group;
            Difficulty = difficulty;
            Type = type;
            Date = DateTime.Now;
            IsCompleted = false;
        }
    }    
}
