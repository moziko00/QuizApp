namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question
                (
                     "What is the capital of Germany?",
                     new string[] { "Berlin", "Munich", "Frankfurt", "Hamburg" },
                     0
                ),
                 new Question
                (
                     "What is 2+2?",
                     new string[] { "4", "5", "6", "7" },
                     0
                )
            };


            Quiz quiz = new Quiz(questions);
            quiz.StartQuiz();

            Console.ReadKey();
        }
    }
}
