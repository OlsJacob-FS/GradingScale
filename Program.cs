using System;
using System.Runtime.CompilerServices;

namespace GradingScale
{
    public class Program
    {
        public static void Main()
        {
            var enteringScore = false;
            do
            {
                //Prompt user for score input:
                Console.WriteLine("Please enter your test score. (0-100)");
                var userScore = Console.ReadLine();
                int testScore;
                if(!int.TryParse(userScore, out testScore))
                {
                    Console.WriteLine("Invalid Entry. Please try again.");
                    enteringScore = true;
                }

                var scoreGrade = testScore switch
                {
                    > 100 => "Invalid entry. Please tru again.",
                    <= 100 and >= 90 => "Grade A: Excellent",
                    <= 89 and >= 80 => "Grade B: Very Good",
                    <= 79 and >= 70 => "Grade C: Good",
                    <= 69 and >= 60 => "Grade D: Needs Improvement",
                    _ => "Fail: Better Luck Next Time",
                };
                Console.WriteLine(scoreGrade);
                enteringScore = false;
            }while(enteringScore);
            NextScore();
        }

        static void NextScore()
        {
            bool enterAnotherScore = false;
            do
            {
                Console.WriteLine("Would you like to enter another score? (Yes/No)");
                var userAnswer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userAnswer))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                    enterAnotherScore = true;
                } else if(userAnswer == "yes" || userAnswer == "y")
                {
                    Main();
                    enterAnotherScore = false;
                } else if(userAnswer == "no" || userAnswer == "n")
                {
                    Console.WriteLine("Thank you for entering your scores.");
                    enterAnotherScore = false;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                    enterAnotherScore = true;
                }
            } while (enterAnotherScore);
        }
    }
}
