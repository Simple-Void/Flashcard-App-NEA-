using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project_UI
{
    static class Global
    {
        //change this back
        private static bool _teacherLoggedIn = false;
        public static bool teacherLoggedIn
        {
            get { return _teacherLoggedIn; }
            set { _teacherLoggedIn = value; }
        }
    }

    //create the object type of flashcard
    public class Flashcard
    {
        //all ther variables and arrays a flashcard will need
        public int ID;
        public string term;
        public string definition;
        public string pictureLocation;
        public string[] questions;
        public string[] falseAnswers;
        public int[] tags;
        public int[] successRate;

        //the actual creation code
        //reference this to create a flashcard
        public Flashcard(int ID, string term, string definition,
            string pictureLocation, string[] questions, string[] falseAnswers,
            int[] tags, int[] successRate)
        {
            //takes the information passed to the creator and makes an
            //actual flashcard object with it
            this.ID = ID;
            this.term = term;
            this.definition = definition;
            this.pictureLocation = pictureLocation;
            this.questions = questions;
            this.falseAnswers = falseAnswers;
            this.tags = tags;
            this.successRate = successRate;
        }
    }

    //create the object type of set
    public class Set
    {
        //all variables it will need
        public int ID;
        public string name;
        public string resources;
        public int[] cards;
        public int[] tags;

        //object creator
        //reference to make a set
        public Set(int ID, string name, string resources,int[] tags , int[] cards)
        {
            this.ID = ID;
            this.name = name;
            this.resources = resources;
            this.tags = tags;
            this.cards = cards;
        }
    }

    //create the object type of set
    public class TestData
    {
        //all variables it will need
        //true if out of time
        public bool outOfTime;
        public int correct;
        public int incorrect;

        //object creator
        //reference to make a set
        public TestData(bool outOfTime, int correct, int incorrect)
        {
            this.outOfTime = outOfTime;
            this.correct = correct;
            this.incorrect = incorrect;
        }
    }
}
