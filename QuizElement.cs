using System;

namespace QuizGame
{
    abstract class QuizElement
    {
        protected string question;
        protected bool isCorrect;

        // abstract method because every child class answers the question differently
        public abstract void AnswerQuestion();
        protected abstract void EvaluateUserInput(dynamic userInput);

        // writes the current question into the console
        public void OutputQuestion()
        {
            Console.Clear();
            Console.WriteLine(this.question);
        }

        // returns the converted user input
        public int UserInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        // prints whether the given answer was right or wrong
        public void PrintResult()
        {
            switch(this.isCorrect)
            {
                case true:
                    Console.WriteLine("Deine Antwort war richtig");
                    break;
                case false:
                    Console.WriteLine("Deine Antwort war falsch");
                    break;
            }
        }

        // returns the isCorrect value (getter class)
        public bool GetIsCorrect()
        {
            return this.isCorrect;
        }
    }
}