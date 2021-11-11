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
            _grid = new Grid();
            _grid.maxColumns = columns;
            for(int i = 0; i < columns; i++)
            {
                _grid.addColumn(rows);
            }
        }

        public void newPlayer(char symb)
        {
            Player newPlayer = new Player();
            newPlayer.symbol = symb;
            _players.Add(newPlayer);
        }

        public void play()
        {
            bool WIN = false;
            while(!WIN){
                foreach(IPlayer p in _players)
                {
                    _grid.updateGrid(p.makeAMove(_grid.maxColumns), p.getSymbol());
                }

            }
        }
    }
}
