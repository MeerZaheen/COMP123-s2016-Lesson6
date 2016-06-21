using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* Author: 
* Date
* StudentID
* Description: This program tests the player and enemy classes
* Version: 0.01 - Initial Test Version - testing basic classes and methods
*/

namespace PLayerProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Grid grid = new Grid(15, 15);

            TouchingEnemy redEnemy = new TouchingEnemy("red", grid);
            redEnemy.SetPosition(new Vector2().SouthEast(5));
            redEnemy.SetFacing(new Vector2().Zero());
            Console.WriteLine(redEnemy.ToString());
            grid.AddChild(redEnemy);

            Player greenPlayer = new PLayerProject.Player("green", grid);
            greenPlayer.SetPosition(new Vector2(1, 1));
            greenPlayer.SetFacing(redEnemy.Position);
            Console.WriteLine(greenPlayer.ToString());
            grid.AddChild(greenPlayer);

            float distance = new Vector2().Magnitude(greenPlayer.Position, redEnemy.Position);

            Console.WriteLine("Distance between Player and Enemy: " + distance + "\n");

            greenPlayer.MoveRight(5);
            greenPlayer.MoveBack(5);
            greenPlayer.MoveLeft(3);
            greenPlayer.MoveForward(6);
            Console.WriteLine(grid.ToString());

            WaitForAnyKey();
        }

        /**
         * <summary>
         * Utility method to wait for a console key press from the user 
         * </summary>
         * 
         * @method WaitForAnyKey
         * @returns {void}
         */
        public static void WaitForAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}