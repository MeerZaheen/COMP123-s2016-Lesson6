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
            Player greenPlayer = new PLayerProject.Player("green");
            greenPlayer.Facing.x = -3.0f;
            greenPlayer.Facing.y = 3.0f;

            Console.WriteLine(greenPlayer.ToString()); 

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
            Console.WriteLine("+++++++++++++++++++++");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
