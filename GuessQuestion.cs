using System;
using System.Threading;

namespace QuizGame
{
    class GuessQuestion : QuizElement
    {
        private int correctAmount;
        private int tolerance;

        public GuessQuestion(string question, int correctAmount, int tolerance)
        {
            this.question = question;
            this.correctAmount = correctAmount;
            this.tolerance = tolerance;
        }

        public override void AnswerQuestion()
        {
            OutputQuestion();
            Console.WriteLine("Gib einen geschätzten Wert ein");
            int userInput = UserInput();
            EvaluateUserInput(userInput);
            PrintResult();
            Thread.Sleep(3000);
        }

        protected override void EvaluateUserInput(dynamic userInput)
        {
            if(userInput <= correctAmount + tolerance && userInput >= correctAmount - tolerance)
            {
                this.isCorrect = true;
            }
            else
            {
                this.isCorrect = false;
            }
        }
    }
}