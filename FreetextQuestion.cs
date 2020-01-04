using System;
using System.Threading;

namespace QuizGame
{
    class FreetextQuestion : QuizElement
    {
        private string solutionWord;

        public FreetextQuestion(string question, string solutionWord)
        {
            this.question = question;
            this.solutionWord = solutionWord;
        }

        public override void AnswerQuestion()
        {
            OutputQuestion();
            Console.WriteLine("Schreibe das gesuchte Wort exakt (Groß-und Kleinschreibung beachten)");
            string userInput = Console.ReadLine();
            EvaluateUserInput(userInput);
            PrintResult();
            Thread.Sleep(3000);
        }

        protected override void EvaluateUserInput(dynamic userInput)
        {
            if(this.solutionWord == userInput)
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