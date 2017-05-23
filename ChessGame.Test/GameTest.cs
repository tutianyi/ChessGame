using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ChessGame.Test
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void test_default_move()
        {
            Game game = new Game("XOXOX-OXO");
            Assert.AreEqual(5, game.Move('X'));

            game = new Game("XOXOXOOX-");
            Assert.AreEqual(8, game.Move('O'));

            game = new Game("---------");
            Assert.AreEqual(0, game.Move('X'));

            game = new Game("XXXXXXXXX");
            Assert.AreEqual(-1, game.Move('X'));
        }

        [Test]
        public void test_find_winning_move()
        {
            Game game = new Game("XO-XX-OOX");
            Assert.AreEqual(5, game.Move('X'));
        }

        [Test]
        public void test_win_conditions()
        {
            Game game = new Game("---XXX---");
            Assert.AreEqual('X', game.winner());
        }
    }
}
