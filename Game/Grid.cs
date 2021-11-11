using System;
using System.Collections.Generic;

namespace Game {

    public class Column {
        private List<char> _column = new List<char>();
        public int maxMoves {get; set; }

        public void addMove(char symbol) {
            if(_column.Count >= maxMoves)
            {
                throw new ArgumentNullException();
            }
            _column.Add(symbol);
        }
    }

    public class Grid {
        public List<Column> grid = new List<Column>();
        public int maxColumns { get; set; }

        public List<Column> currentGrid() {
            return grid;
        }

        public void addColumn(int rows) {
            Column col = new Column();
            col.maxMoves = rows;
            grid.Add(col);
        }

        public void updateGrid(int move, char symbol){
            grid[move].addMove(symbol);
        }
    }
}