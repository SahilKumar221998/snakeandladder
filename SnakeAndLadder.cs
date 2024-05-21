using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SnakeAndLadder
    {
        int result;
        int rollDice;
        int choice;
        int moves;
       //Asking user for paly or no play if he gets ladder
        public int playLadderOptions()
        {
            Console.WriteLine("Enter the options:-");
            Console.WriteLine("1.No Play\n2.Ladder");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: return 0;
                case 2: return ladder(result);
                default:
                    Console.WriteLine("Invalid options");break ;
            }
            return 0;
        }
        //Method to calculate ladder points 
        public int playSnakeOptions()
        {
            Console.WriteLine("1.No Play\n2.Snake");
            choice=Convert.ToInt32(Console.ReadLine()); 
            switch(choice)
            {
                case 1:return 0;
                case 2:return snake(result);
                default:
                    Console.WriteLine("Invalid options");break ;
            }
            return 0;
        }
        //Method to calculate Ladders in a board
        public int ladder(int number)
        {
           
            if (number == 7)
                return number +=rollDice;
            else if (number == 15)
                return number+=rollDice;
            else if (number == 33)
                return number +=rollDice;
            else if (number == 87)
                number +=rollDice;

            return 0;

        }
        //Method to calculate snakes in a board
        public int snake(int number)
        {
           
            if (number == 13)
                return number -= rollDice;
            else if (number == 46)
                return number -= rollDice;
            else if (number == 72)
                return number -= rollDice;
            else if (number == 98)
                number -= rollDice;

            return 0;
        }
        // Method for Random Roll of a dice between  1 To 6  
        public int dice()
        {
            Random random = new Random();
            int diceRoll = random.Next(1, 6);
            return diceRoll;
        }
        //Method for asking user how many palyers are playing
        public int[] players()
        {
            Console.WriteLine("Enter how many players are playing");
            int palyers = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[palyers];
            return arr;
        }
        //Method to add the each roll of a die until it reaches 100;
        public int calculation( int i)
        {
            result = 0;
            Console.WriteLine("______________________________________");
            Console.WriteLine("Player " + (i+1) + " Moves");
            Console.WriteLine("_______________________________________");
            do
            {
                
                rollDice = dice();
                if (result == 100)
                    break;
                if (ladder(result) != 0 && result <=100)
                {
                    Console.WriteLine("You Got Ladder Pick One Option");
                    result += playLadderOptions();
                }
                else if (snake(result) != 0 && result <=100)
                {
                    Console.WriteLine("You Got Snake Pick One Option");
                    result += playSnakeOptions();
                }
                else if(result<100)
                    result += rollDice;

                if (result >100)
                    result = 100;

                moves++;
            } while (result<100);
            return result;
        }
        //method to check individual palyer score and appending it to a array
        //Index 0 belongs to player 1 and its points.
        public int[] winner()
        {
            int[] arr = players();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = calculation(i);
            }
            return arr;
        }
        static void Main(string[] args)
        {
            SnakeAndLadder snakeAndLadder = new SnakeAndLadder();
            int[] resultArray = snakeAndLadder.winner();
            Console.WriteLine("____________________________________________________");
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[i] == 100)
                {
                    Console.WriteLine("Player " + (i + 1) + " is a Winner");
                    break;
                }

            }
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine("Nunber of Dice Roll Is :- "+snakeAndLadder.moves);
        }
    }
}
