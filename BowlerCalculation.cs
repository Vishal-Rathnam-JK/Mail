using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation_BowlerEconomyAndStrikerate
{
    class BowlerCalculation
    {
        public static void Main()
        {
            float oversBowled;
            string deliveryInformation;
            float wicketsTaken = 0;
            float ballsBowled = 0;
            string reset = "none";
            float runsScored = 0;
            double economyRate;
            double strikeRate;           
            do
            {
                reset = "none";
                Console.Write("Enter the number of overs bowled :");
                oversBowled = float.Parse(Console.ReadLine());
                if (oversBowled < 0 || (oversBowled > 0.5 && oversBowled < 1) || oversBowled > 1.5)
                {
                    reset = "repeat";
                }
            } while (reset=="repeat");
            string[] oversArray = Convert.ToString(oversBowled).Split('.');
            ballsBowled = int.Parse(oversArray[0]) * 6 + int.Parse(oversArray[1]);
            Console.Write("Enter the runs scored on each ball , seperated by commas");         
            do
            {
                reset = "none";
               deliveryInformation = Console.ReadLine();
               string[] deliveryArray = deliveryInformation.Split(',');
                if (deliveryArray.Count()!=ballsBowled)
                {
                    reset = "repeat";
                }
                
                foreach (string item in deliveryArray)
                {
                    if (item=="W" || item == "w")
                    {
                        wicketsTaken++;  
                    }
                    else if (int.Parse(item) < 7)
                    {
                        runsScored = runsScored + int.Parse(item);
                    }
                    else
                    {
                        reset = "repeat";
                    }  
                }
            } while (reset=="repeat");
            economyRate = runsScored * 6 / ballsBowled;
            strikeRate = wicketsTaken / ballsBowled;
                Console.WriteLine("The Economy Rate = {0} \n Strike Rate = {1}", economyRate,strikeRate);                         
        }
    }
}
