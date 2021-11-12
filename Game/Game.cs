using System;
using System.Collections.Generic;

namespace Game
{
    public class Game
    {
        private Grid _grid;
        private ICollection<IPlayer> _players;

        public void newGrid(int rows, int columns)
        {
            _grid = new Grid(columns, rows);
        }

        public void newPlayer(char symb)
        {
            Player newPlayer = new Player();
            newPlayer.Symbol = symb;
            _players.Add(newPlayer);
        }

        public void newDumbAI(char symb)
        {
            DumbAI newPlayer = new DumbAI();
            newPlayer.Symbol = symb;
            _players.Add(newPlayer);
        }

        public void play()
        {
            //Chaque joueur joue chacun son tour. Le jeu est terminé si la grille est pleine ou si un des joueurs a gagné
            foreach(IPlayer p in _players)
            {
                _grid.updateGrid(p.makeAMove(_grid.maxColumns), p.Symbol);
            }
        }
    }
}
