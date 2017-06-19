using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class CoordinateConversion
    {
        public char translateNumberToLetter(int x)
        {
            char c = Convert.ToChar(x+64);

            return c;
        }

        public int translateLetterToNumber(char x)
        {
            int i = Convert.ToInt32(x);
            i -= 64;

            return i;
        }
    }
}
