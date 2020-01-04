using System;
using System.Collections.Generic;
using System.Xml;

namespace QuizGame
{
    class QuizStarter
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\Git_Repositories\External-Quiz\Elements.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodeList = doc.SelectNodes("/QuizElement");
            XmlNodeList childNodes = nodeList[0].ChildNodes;
            XmlNode yesNoElement1 = childNodes[0];
            XmlNode yesNoElement2 = childNodes[1];
            XmlNode freetextElement1 = childNodes[2];
            XmlNode guessElement1 = childNodes[3];
            XmlNode multipleChoiceElemement1 = childNodes[4];

            string yesNoQuestion1 = yesNoElement1.Attributes[0].Value;
            bool yesNoBool1 = bool.Parse(yesNoElement1.Attributes[1].Value);
            string yesNoQuestion2 = yesNoElement2.Attributes[0].Value;
            bool yesNoBool2 = bool.Parse(yesNoElement2.Attributes[1].Value);
            string freetextQuestion1 = freetextElement1.Attributes[0].Value;
            string solutionWord1 = freetextElement1.Attributes[1].Value;
            string guessQuestion1 = guessElement1.Attributes[0].Value;
            int correctAmount1 = Int32.Parse(guessElement1.Attributes[1].Value);
            int tolerance1 = Int32.Parse(guessElement1.Attributes[2].Value);
            string multipleChoiceQuestion1 = multipleChoiceElemement1.Attributes[0].Value;
            string multipleChoiceAnswer1 = multipleChoiceElemement1.ChildNodes[0].InnerText;
            string multipleChoiceAnswer2 = multipleChoiceElemement1.ChildNodes[1].InnerText;
            string multipleChoiceAnswer3 = multipleChoiceElemement1.ChildNodes[2].InnerText;
            List<string> multipleChoiceAnswers = new List<string>();
            multipleChoiceAnswers.Add(multipleChoiceAnswer1);
            multipleChoiceAnswers.Add(multipleChoiceAnswer2);
            multipleChoiceAnswers.Add(multipleChoiceAnswer3);
            bool multipleChoiceBool1 = bool.Parse(multipleChoiceElemement1.ChildNodes[0].Attributes[0].Value);
            bool multipleChoiceBool2 = bool.Parse(multipleChoiceElemement1.ChildNodes[1].Attributes[0].Value);
            bool multipleChoiceBool3 = bool.Parse(multipleChoiceElemement1.ChildNodes[2].Attributes[0].Value);
            List<bool> multipleChoiceBooleans = new List<bool>();
            multipleChoiceBooleans.Add(multipleChoiceBool1);
            multipleChoiceBooleans.Add(multipleChoiceBool2);
            multipleChoiceBooleans.Add(multipleChoiceBool3);

            YesNoQuestion question1 = new YesNoQuestion(yesNoQuestion1, yesNoBool1);
            YesNoQuestion question2 = new YesNoQuestion(yesNoQuestion2, yesNoBool2);
            FreetextQuestion question3 = new FreetextQuestion(freetextQuestion1, solutionWord1);
            GuessQuestion question4 = new GuessQuestion(guessQuestion1, correctAmount1, tolerance1);
            MultipleChoiceQuestion question5 = new MultipleChoiceQuestion(multipleChoiceQuestion1, multipleChoiceAnswers, multipleChoiceBooleans);

            List<QuizElement> list = new List<QuizElement>();
            list.Add(question1);
            list.Add(question2);
            list.Add(question3);
            list.Add(question4);
            list.Add(question5);
            QuizGame game = new QuizGame(list);
            game.GameLoop(game);    
        }
    }
}