using System;
using System.Collections.Generic;

namespace Game {

    public class Column {
        private List<char> _column = new List<char>();
        public int maxMoves {get; set; }

        public Column(int m){
            maxMoves = m;
        }

        public List<char> getColumn() {
            return _column;
        }

        public bool isFull()
        {
            return _column.Count >= maxMoves;
        }

        public void addMove(char symbol) {
            if(this.isFull())
            {
                throw new ArgumentNullException();
            }
            else _column.Add(symbol);
        }
    }

    public class Grid {
        public List<Column> _grid = new List<Column>();
        public int maxColumns { get; set; }

        public Grid(int x, int y){
            if(x < 4 || y < 4) throw new ArgumentNullException();
            maxColumns = x;
            for(int i = 0; i < x; i++)
            {
                this.addColumn(y);
            }
        }

        public List<Column> currentGrid() {
            return _grid;
        }

        public void addColumn(int rows) {
            Column col = new Column(rows);
            _grid.Add(col);
        }

        public void updateGrid(int move, char symbol){
            if(move < 0 || move >= maxColumns) throw new ArgumentNullException();
            else _grid[move].addMove(symbol);
        }

        public void cleanGrid(){
            foreach(Column column in _grid){
                column.getColumn().Clear();
            }
        }

        public bool isValidMove(int move)
        {
            return (move > this.maxColumns && move < this.maxColumns && _grid[move].isFull());
        }

        public bool checkForWinner(char player)
        {
            int vCounter = 0;
            //Vertical
            foreach(Column column in _grid){
                //Inutile de verifier des colonnes avec moins de 4 jetons
                if (column.getColumn().Count < 4) continue;
                for(int i = 0; i < column.getColumn().Count ; i++)
                {
                    if(column.getColumn()[i] == player) vCounter++;
                    else vCounter = 0;
                    //Console.WriteLine( (column.getColumn()[i] == player) ? column.getColumn()[i] + " " + vCounter : column.getColumn()[i] );
                    if (vCounter == 4) return true;
                }
            }

            
            //Horizontale
            for(int i = 0 ; i < (_grid.Count - 3); i++)
            {
                if(_grid[i].getColumn().Count == 0 || _grid[i+1].getColumn().Count == 0 || _grid[i+2].getColumn().Count == 0 || _grid[i+3].getColumn().Count == 0) continue;
                for (int j = 0; j < _grid[i].getColumn().Count ; j++)
                {
                    if (_grid[i+1].getColumn().Count <= j || _grid[i+2].getColumn().Count <= j || _grid[i+3].getColumn().Count <= j) continue;
                    if (_grid[i].getColumn()[j] == player && _grid[i+1].getColumn()[j] == player && _grid[i+2].getColumn()[j] == player && _grid[i+3].getColumn()[j] == player ) return true;
                }
            }

            //Diagonale ascendante
            for(int i = 0 ; i < (_grid.Count - 3); i++)
            {
                if(_grid[i].getColumn().Count == 0 || _grid[i+1].getColumn().Count == 0 || _grid[i+2].getColumn().Count == 0 || _grid[i+3].getColumn().Count == 0) continue;
                for (int j = 0; j < _grid[i].getColumn().Count ; j++)
                {
                    if (_grid[i+1].getColumn().Count <= j+1 || _grid[i+2].getColumn().Count <= j+2 || _grid[i+3].getColumn().Count <= j+3) continue;
                    if (_grid[i].getColumn()[j] == player && _grid[i+1].getColumn()[j+1] == player && _grid[i+2].getColumn()[j+2] == player && _grid[i+3].getColumn()[j+3] == player ) return true;
                }
            }

            //Diagonale descendante
            for(int i = 0 ; i < (_grid.Count - 3); i++)
            {
                if(_grid[i].getColumn().Count == 0 || _grid[i+1].getColumn().Count == 0 || _grid[i+2].getColumn().Count == 0 || _grid[i+3].getColumn().Count == 0) continue;
                for (int j = 3; j < _grid[i].getColumn().Count ; j++)
                {
                    if (_grid[i].getColumn()[j] == player && _grid[i+1].getColumn()[j-1] == player && _grid[i+2].getColumn()[j-2] == player && _grid[i+3].getColumn()[j-3] == player ) return true;
                }
            }

            return false;
        }
    }
}