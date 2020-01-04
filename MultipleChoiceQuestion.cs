using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace QuizGame
{
    class MultipleChoiceQuestion : QuizElement
    {
        private List<string> answers;
        private List<bool> isAnswerTrue;
        private List<bool> correctAnswers;
        private List<bool> givenAnswers;

        public MultipleChoiceQuestion(string question, List<string> answers, List<bool> isAnswerTrue)
        {
            this.question = question;
            this.answers = answers;
            this.isAnswerTrue = isAnswerTrue;
            this.correctAnswers = new List<bool>();
            this.givenAnswers = new List<bool>();
        }

        public override void AnswerQuestion()
        {
            OutputQuestion();
            OutputAnswers();
            CalculateNumberOfCorrectAnswers();
            Console.WriteLine("Beantworte diese Frage mit Zahlen zwischen 0 und " + (GetNumberOfAnswers() - 1));
            Console.WriteLine("Es gibt insgesamt " + GetNumberOfCorrectAnswers() + " richtige Antworten");
            for(int i = 0; i < GetNumberOfCorrectAnswers(); i++)
            {
                int userInput = UserInput();
                EvaluateUserInput(userInput);
            }
            PrintResult();
            this.givenAnswers.Clear();
            Thread.Sleep(3000);
        }

        // prints the answer options
        private void OutputAnswers()
        {
            for(int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + this.answers[i]);
            }
        }

        // calculates the amount of correct answers in all answers
        private void CalculateNumberOfCorrectAnswers()
        {
            this.correctAnswers.Clear();
            for(int i = 0; i < GetNumberOfAnswers(); i++)
            {
                if(this.isAnswerTrue[i] == true)
                {
                    this.correctAnswers.Add(isAnswerTrue[i]);
                }
            }
        }

        // returns the amount of all answers
        private int GetNumberOfAnswers()
        {
            return this.answers.Count;
        }

        // returns the amount of correct answers
        private int GetNumberOfCorrectAnswers()
        {
            return this.correctAnswers.Count;
        }

        protected override void EvaluateUserInput(dynamic userInput)
        {
            this.givenAnswers.Add(isAnswerTrue[userInput]);
            if(givenAnswers.All(correctAnswers.Contains))
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