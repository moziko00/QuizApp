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
                )
            };


            Quiz quiz = new Quiz(questions);
            quiz.DisplayQuestion(questions[0]);

            Console.ReadKey();
        }
    }
}
