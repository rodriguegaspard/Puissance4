using NUnit.Framework;
using Game;
using System;

namespace Game.Tests
{
    public class Tests
    {
        private IPlayer playerOne;
        private int numberOfColumns;
        private Column tinyColumn;

        [SetUp]
        public void Setup()
        {
            playerOne = new Player();
            numberOfColumns = 10;
            tinyColumn = new Column();
            tinyColumn.maxMoves = 1;
        }

        [Test]
        public void PlayerMustReturnPositiveInteger()
        {
            //On teste si le joueur retourne un numéro de colonne valide (entier >= 0)
            Assert.AreEqual(true, playerOne.makeAMove(numberOfColumns) >= 0, "Result must be a positive integer");
        }

        [Test]
        public void PlayerMustReturnValidColumnNumber()
        {
            //On teste si le joueur retourne un numéro de colonne existante
            Assert.AreEqual(true, (playerOne.makeAMove(numberOfColumns) <= numberOfColumns), "Result must be inferior or equal to the numbers of columns");
        }

        [Test]
        public void OverflowingAColumnShouldThrowException()
        {
            //Ajouter un jeton sur une colonne remplie doit retourner une exception
            Assert.Catch<ArgumentNullException>(() => tinyColumn.addMove('X'));
        }


    }
}