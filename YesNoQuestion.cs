using System;
using System.Threading;

namespace QuizGame
{
    class YesNoQuestion : QuizElement
    {
        private bool isQuestionTrue;

        public YesNoQuestion(string question, bool isQuestionTrue)
        {
            this.question = question;
            this.isQuestionTrue = isQuestionTrue;
        }

        // writes the current question into the console
        public override void AnswerQuestion()
        {
            OutputQuestion();
            Console.WriteLine("Beantorte diese Frage mit 1 = ja und 0 = nein");
            int userInput = UserInput();
            EvaluateUserInput(userInput);
            PrintResult();
            Thread.Sleep(3000);
        }

        // evaluates given user input and accordingly sets the isCorrect value
        protected override void EvaluateUserInput(dynamic userInput)
        {
            switch(userInput)
            {
                case 0:
                    if(this.isQuestionTrue)
                    {
                        this.isCorrect = false;
                    }
                    else
                    {
                        this.isCorrect = true;
                    }
                    break;
                case 1:
                    if(this.isQuestionTrue)
                    {
                        this.isCorrect = true;
                    }
                    else
                    {
                        this.isCorrect = false;
                    }
                    break;
                default:
                    this.isCorrect = false;
                    break;
            }
        }
    }
}