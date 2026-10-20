using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score;
        public Quiz(Question[] questions)
        {
            this._questions = questions;
            _score = 0;
        }
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1; // to display the question number

            foreach(var question in _questions)
            {
                Console.WriteLine($"Question {questionNumber++}:");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();

                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The Correct Answer was: {question.Answers[question.CorrectAnswerIndex]}");
                }
            }
        }
        private void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Quiz finished. Your Score is : {_score} out of {_questions.Length} ");
            
            double percentage = ((double)_score / _questions.Length) * 100;
            if (percentage >= 0.8)
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine("Excellent Work!");
            }
            else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep Practicing!");
            }
            Console.ResetColor();

        }

        private void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);

            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; // changes the text color
                Console.Write("   ");
                Console.Write(i + 1);
                Console.ResetColor(); // resets the foreground (text) color
                Console.WriteLine($". {question.Answers[i]}");
            }
            
        }

        private int GetUserChoice()
        {
            Console.Write("Enter answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid Choice. Please Eneter a number between 1 and 4");
                input = Console.ReadLine();
            }
            return choice - 1; // Subtract 1 to convert to zero-based index
        }
    } 
}
