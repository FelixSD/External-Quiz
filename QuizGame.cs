using System;
using System.Collections.Generic;
using System.Threading;

namespace QuizGame
{
    // represents the whole quiz-game
    class QuizGame
    {
        private int answeredQuestions;
        private int correctlyAnsweredQuestions;
        private List<QuizElement> quizElements;

        public QuizGame(List<QuizElement> quizElements)
        {
            this.answeredQuestions = 0;
            this.correctlyAnsweredQuestions = 0;
            this.quizElements = quizElements;
        }
        
        // loops through the list of quiz-questions and starts the game
        public void GameLoop(QuizGame game)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Du hast " + game.GetAnsweredQuestions() + " Fragen insgesamt beantwortet.");
                Console.WriteLine("Von diesen hast du " + game.GetCorrectlyAnsweredQuestions() + " Fragen richtig beantwortet.");
                Thread.Sleep(6000);
                game.AnswerQuizElement();
            }
        }

        // adds a quiz-element to the list of quiz-elements
        public void AddQuizElement(QuizElement quizElement)
        {
            this.quizElements.Add(quizElement);
        }

        // shuffles the quiz-elements, outputs the question (AnswerQuestion()) and increments the answered questions
        public void AnswerQuizElement()
        {
            quizElements.Shuffle();
            QuizElement quizElement = quizElements[0];
            quizElement.AnswerQuestion();
            if(quizElement.GetIsCorrect())
            {
                this.correctlyAnsweredQuestions++;
            }
            this.answeredQuestions++;
        }

        // returns the answeredQuestions value (getter-class)
        public int GetAnsweredQuestions()
        {
            return this.answeredQuestions;
        }

        // returns the correctlyAnsweredQuestions value (getter-class)
        public int GetCorrectlyAnsweredQuestions()
        {
            return this.correctlyAnsweredQuestions;
        }
    }
}