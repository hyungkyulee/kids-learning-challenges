using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
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