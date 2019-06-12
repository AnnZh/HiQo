using System;

namespace Game
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int rolled = 0;
        public void Roll(int pins)
        {
            if (pins > 10 || pins < 0)
                throw new ArgumentException();
            if (rolled > 20)
                throw new IndexOutOfRangeException();
            //if (pins <= 10 && pins >= 0 && rolled < 21)
            //{
            rolls[rolled++] = pins;
            //}
        }

        public int Score()
        {
            int index = 0;
            int score = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[index] == 10)
                {
                    score += rolls[index] + rolls[index + 1] + rolls[index + 2];
                    index++;
                }
                else if (rolls[index] + rolls[index + 1] == 10)
                {
                    score += rolls[index] + rolls[index + 1] + rolls[index + 2];
                    index += 2;
                }
                else
                {
                    score += rolls[index] + rolls[index + 1];
                    index += 2;
                }
            }
            return score;
        }
    }
}
