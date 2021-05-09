using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

// public Guid Id { get; set; }
// public string Question { get; set; }
// public DateTime Date { get; set; }
// public string Description { get; set; }
// public string Category { get; set; }
// public string Answer { get; set; }
// public string WrongAnswer1 { get; set; }
// public string WrongAnswer2 { get; set; }
// public string WrongAnswer3 { get; set; }
// public string WrongAnswer4 { get; set; }
// public string WrongAnswer5 { get; set; }

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.WordGames.Any()) return;

            var testWordGames = new List<WordGame>
            {
                new WordGame
                {
                    Question = "Wrath",
                    Date = DateTime.Now,
                    Description = "do it",
                    Category = "Synonyms",
                    Answer = "anger",
                    WrongAnswer1 = "crime",
                    WrongAnswer2 = "knot",
                    WrongAnswer3 = "smoke",
                    WrongAnswer4 = "happiness",
                    WrongAnswer5 = "sadness",
                },
                new WordGame
                {
                    Question = "pompous",
                    Date = DateTime.Now,
                    Description = "do it",
                    Category = "Synonyms",
                    Answer = "arrogant",
                    WrongAnswer1 = "gaudy",
                    WrongAnswer2 = "busy",
                    WrongAnswer3 = "supportive",
                    WrongAnswer4 = "humble",
                    WrongAnswer5 = "greedy",
                },
                new WordGame
                {
                    Question = "calamity",
                    Date = DateTime.Now,
                    Description = "do it",
                    Category = "Synonyms",
                    Answer = "arrogant",
                    WrongAnswer1 = "gaudy",
                    WrongAnswer2 = "busy",
                    WrongAnswer3 = "supportive",
                    WrongAnswer4 = "humble",
                    WrongAnswer5 = "greedy",
                }
            };

            await context.WordGames.AddRangeAsync(testWordGames);
            await context.SaveChangesAsync();
        }
    }
}