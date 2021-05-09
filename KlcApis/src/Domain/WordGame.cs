using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class WordGame
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Answer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string WrongAnswer4 { get; set; }
        public string WrongAnswer5 { get; set; }
    }
}