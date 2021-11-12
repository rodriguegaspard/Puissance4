using System;

namespace Game{
    public class Player : IPlayer {
        //Les joueurs sont représentés par un caractère
        public char Symbol {get; set; }

        public int makeAMove(Grid grid){
            Console.WriteLine("Entrez un numéro entre 1 et " + grid.maxColumns + ".");
            string input = Console.ReadLine();
            int move = -1;

            while(!Int32.TryParse(input, out move) || !grid.isValidMove(move))
            {
                Console.WriteLine("ERREUR. Veuillez entrer un numéro de colonne valide!");
                input = Console.ReadLine();
            }

            return move;
    }

}
}