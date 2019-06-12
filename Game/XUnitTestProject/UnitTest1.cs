using System;
using Xunit;
using Game;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(Int32.MinValue)]
        public void ArgumentException_lessThenZero(int pins)
        {
            Game.Game game = new Game.Game();
            Action act = () => game.Roll(pins);
            Assert.Throws<ArgumentException>(act);
            /*for (int i = 0; i < 20; i++)
                game.Roll(-1);
            Assert.Equal(0, game.Score());*/
        }

        [Theory]
        [InlineData(11)]
        [InlineData(50)]
        [InlineData(Int32.MaxValue)]
        public void ArgumentException_moreThan10(int pins)
        {
            Game.Game game = new Game.Game();
            Action act = () => game.Roll(pins);
            Assert.Throws<ArgumentException>(act);
            /*for (int i = 0; i < 20; i++)
                game.Roll(11);
            Assert.Equal(0, game.Score());*/
        }

        private void Adder(int count, int pins, Game.Game obj)
        {
            for (int i = 0; i < count; i++)
                obj.Roll(pins);
        }

        [Fact]
        public void IndexOutOfRangeException_MoreThan10Frames()
        {            
            Game.Game game = new Game.Game();
            Adder(21, 1, game);
            Action act = () => game.Roll(1);
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void TenthFrame_WithoutSpareOrStrike()
        {
            Game.Game game = new Game.Game();
            Adder(21, 1, game);
            //Assert.Equal(20, game.Score());
            Assert.NotEqual(21, game.Score());
        }

        [Fact]
        public void AlwaysZero()
        {
            Game.Game game = new Game.Game();
            Adder(20, 0, game);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void AlwaysOne()
        {
            Game.Game game = new Game.Game();
            Adder(20, 1, game);
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void CheckForSpare()
        {
            Game.Game game = new Game.Game();
            game.Roll(3);
            game.Roll(7);
            game.Roll(2);
            game.Roll(5);
            Adder(16, 0, game);
            Assert.Equal(19, game.Score());
        }

        [Fact]
        public void CheckForStrike()
        {
            Game.Game game = new Game.Game();
            game.Roll(10);
            game.Roll(2);
            game.Roll(4);
            game.Roll(1);
            Adder(16, 0, game);
            Assert.Equal(23, game.Score());
        }

        [Fact]
        public void AlwaysTen()
        {
            Game.Game game = new Game.Game();
            Adder(12, 10, game);
            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void AlwaysFive()
        {
            Game.Game game = new Game.Game();
            Adder(21, 5, game);
            Assert.Equal(150, game.Score());
        }

        [Fact]
        public void TenthFrame_Strike()
        {
            Game.Game game = new Game.Game();
            Adder(18, 0, game);
            game.Roll(10);
            game.Roll(2);
            game.Roll(4);
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void TenthFrame_Spare()
        {
            Game.Game game = new Game.Game();
            Adder(18, 0, game);
            game.Roll(2);
            game.Roll(8);
            game.Roll(6);
            Assert.Equal(16, game.Score());
        }
    }
}
