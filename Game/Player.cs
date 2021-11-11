using System;

namespace Game{
    public class Player : IPlayer {
        //Les joueurs sont représentés par un caractère
        public char Symbol {get; set; }

        public int makeAMove(int columns){
            Console.WriteLine("Entrez un numéro entre");
            string input = Console.ReadLine();
            int move = -1;

            while(!Int32.TryParse(input, out move) || move > columns || move < columns)
            {
                Console.WriteLine("ERREUR. Veuillez entrer un numéro de colonne valide!");
                input = Console.ReadLine();
            }

            return move;
    }

    public char getSymbol()
    {
        return player.symbol;
    }
}
}