using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project_UI
{
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

        //object creator
        //reference to make a set
        public Set(int ID, string name, string resources, int[] cards)
        {
            this.ID = ID;
            this.name = name;
            this.resources = resources;
            this.cards = cards;
        }
    }
}
