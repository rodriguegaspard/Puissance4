using NUnit.Framework;
using Game;
using System;

namespace Game.Tests
{
    public class Tests
    {
        Grid _uselessGrid;
        Grid _filledGrid;
        Grid _tinyGrid;
        Grid _WinGrid;

        [SetUp]
        public void Setup()
        {
            _uselessGrid = new Grid(4,4);
            _filledGrid = new Grid(4,4);
            _WinGrid = new Grid(10,10);
        }

        [Test]
        public void OutofBoundsMoveShouldThrowException()
        {
            //Placer un jeton dans une colonne non-existante doit renvoyer une exception
            Assert.Catch<ArgumentNullException>(() => _uselessGrid.updateGrid(-1, '#'));
            Assert.Catch<ArgumentNullException>(() => _uselessGrid.updateGrid(100, '#'));
        }

        [Test]
        public void PlayingOnFilledColumnShouldThrowException()
        {
             //Placer un jeton dans une colonne pleine doit renvoyer une exception
            _filledGrid.updateGrid(0, 'X');
            _filledGrid.updateGrid(0, '0');
            _filledGrid.updateGrid(0, 'X');
            _filledGrid.updateGrid(0, '0');
             Assert.Catch<ArgumentNullException>(() => _filledGrid.updateGrid(0, 'X'));
        }

        [Test]
        public void GridShouldBeBigEnoughToHaveAWinner()
        {
            //Une grille doit faire au moins 4x4 pour que l'on puisse gagner verticalement, horizontalement, ou diagonalement
            Assert.Catch<ArgumentNullException>(() => _tinyGrid = new Grid(1,100));
            Assert.Catch<ArgumentNullException>(() => _tinyGrid = new Grid(100,1));
            Assert.Catch<ArgumentNullException>(() => _tinyGrid = new Grid(1,1));
        }

        [Test]
        public void VerticalWin()
        {
            _WinGrid.cleanGrid();

            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, '0');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, '0');
            _WinGrid.updateGrid(0, '0');
            _WinGrid.updateGrid(0, '0');

            Assert.AreEqual(true, _WinGrid.checkForWinner('X'));
            Assert.AreEqual(false, _WinGrid.checkForWinner('0'));
        }

        [Test]
        public void HorizontalWin()
        {
            _WinGrid.cleanGrid();

            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(1, '0');
            _WinGrid.updateGrid(2, 'X');
            _WinGrid.updateGrid(3, 'X');
            _WinGrid.updateGrid(4, 'X');
            _WinGrid.updateGrid(5, 'X');
            _WinGrid.updateGrid(6, '0');
            _WinGrid.updateGrid(7, '0');
            _WinGrid.updateGrid(8, '0');

            Assert.AreEqual(true, _WinGrid.checkForWinner('X'));
            Assert.AreEqual(false, _WinGrid.checkForWinner('0'));
        }

        [Test]
        public void AscendingDiagonalWin()
        {
            /*  
                0 X
              0 X 0
            0 X 0 X
            X 0 0 X

            */

            _WinGrid.cleanGrid();

            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, '0');
            _WinGrid.updateGrid(1, '0');
            _WinGrid.updateGrid(1, 'X');
            _WinGrid.updateGrid(1, '0');
            _WinGrid.updateGrid(2, '0');
            _WinGrid.updateGrid(2, '0');
            _WinGrid.updateGrid(2, 'X');
            _WinGrid.updateGrid(2, '0');
            _WinGrid.updateGrid(3, 'X');
            _WinGrid.updateGrid(3, 'X');
            _WinGrid.updateGrid(3, '0');
            _WinGrid.updateGrid(3, 'X');

            Assert.AreEqual(true, _WinGrid.checkForWinner('X'));
            Assert.AreEqual(false, _WinGrid.checkForWinner('0'));
        }

        [Test]
        public void DescendingDiagonalWin()
        {
            /*  
            X   0 X
            X X X 0
            0 0 X X
            X 0 0 X

            */

            _WinGrid.cleanGrid();

            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, '0');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(0, 'X');
            _WinGrid.updateGrid(1, '0');
            _WinGrid.updateGrid(1, '0');
            _WinGrid.updateGrid(1, 'X');
            _WinGrid.updateGrid(2, '0');
            _WinGrid.updateGrid(2, 'X');
            _WinGrid.updateGrid(2, 'X');
            _WinGrid.updateGrid(2, '0');
            _WinGrid.updateGrid(3, 'X');
            _WinGrid.updateGrid(3, 'X');
            _WinGrid.updateGrid(3, '0');
            _WinGrid.updateGrid(3, 'X');

            Assert.AreEqual(true, _WinGrid.checkForWinner('X'));
            Assert.AreEqual(false, _WinGrid.checkForWinner('0'));
        }
    }
}