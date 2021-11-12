using System;

namespace Game {

    public class SmartAI : IPlayer
    {
        //Les joueurs sont représentés par un caractère
        public char Symbol {get; set; }

        public int makeAMove(Grid grid)
        {
            Random rand = new Random();
            while(true){
                int choice = rand.Next(grid.maxColumns);
                if (grid.isValidMove(choice)) return choice;
            }

        }
    }
}