using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
           GameView gameView = new GameView();
           GameInput gameInput = new GameInput();
           GameManager gm = new GameManager(gameView, gameInput);
           gm.PlayGame();
        }
    }
}
