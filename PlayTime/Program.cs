using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTime
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            decimal UserInput;
            bool cont = true;
            while (cont)
            {//Menu of choices. pressing any of 1-6 works, nothing else will.
                Console.Clear();
                Console.WriteLine("User Menu: \n");
                Console.WriteLine("1.) Initiative Check\n");
                Console.WriteLine("2.) Attack Roll\n");
                Console.WriteLine("3.) Damage Roll\n");
                Console.WriteLine("4.) Ability Check\n");
                Console.WriteLine("5.) Passive Perception\n");
                Console.WriteLine("6.) End the program\n");
                UserInput = Check();
                Console.Clear();
                switch (UserInput)
                {//switch for choice of operation. each has it's own method, that may in turn call on another method.
                    case 1:
                        Console.WriteLine("\nYour Initiative is: " + Initiative());
                        break;
                    case 2:
                        Console.WriteLine("\nYour attack total to hit is: " + Attack());
                        break;
                    case 3:
                        Console.Write("\nYour total damage is: " + Damage());
                        break;
                    case 4:
                        Console.WriteLine("\nYour ability check total is: " + Ability());
                        break;
                    case 5:
                        Console.WriteLine("\nYour passive perception is: " + PassPerc());
                        break;
                    case 6:
                        cont = false;
                        break;
                }
                Console.WriteLine("Thanks for playing.");
                Console.ReadKey();
            }
        }
        //Working Initiative Calculator
        private static decimal Initiative()
        {
            decimal Initiative;
            //d20 plus any pluses.
            Console.WriteLine("What is your Initiative bonus?\n");
            Initiative = Check();
            return rnd.Next(1, 21) + Initiative;
        }
        //Working Attack Calculator
        private static decimal Attack()
        {
            decimal attack;
            decimal dexstr;
            decimal prof;
            decimal bns;
            //Attack calc with either dex or str, prof, and any bonuses. adds a d20 to it all for a total.
            Console.WriteLine("\nPress enter to check Dexterity or Strength Bonus, whichever applies.\nIf none, enter 0.\n");
            dexstr = Check();
            Console.Clear();
            Console.WriteLine("\nPress enter to check Proficiency Bonus, whichever applies.\nIf none, enter 0.\n");
            prof = Check();
            Console.Clear();
            Console.WriteLine("\nPress enter to check any other Bonus(es), whichever applies.\nIf none, enter 0.\n");
            bns = Check();
            Console.Clear();
            attack = dexstr + prof + bns + rnd.Next(1, 21);
            return attack;
        }
        //Working Damage Calculator
        private static decimal Damage()
        {
            decimal damage;
            decimal dexstr;
            decimal bns;
            //damage checker. all inputs checked, and if valid, added with a dice roll that is chosen in the diceroll method.
            Console.WriteLine("Enter to check Dexterity or Strength Bonus, if applicable.\n If none, enter 0.");
            dexstr = Check();
            Console.Clear();
            Console.WriteLine("\nEnter to check any other Bonus(es), if applicable.\n If none, enter 0.");
            bns = Check();
            Console.Clear();
            damage = DiceRoll() + bns + dexstr;
            return damage;
        }
        //Working Ability Check Calculator
        private static decimal Ability()
        {
            decimal answer;
            decimal entry;
            //All ability checks are the same. d20 + pluses. That's what this is.
            Console.WriteLine("Please enter your skill bonus.\n");
            entry = Check();
            answer = entry + rnd.Next(1, 21);
            return answer;
        }
        //Working Passive Perception Calculator
        private static decimal PassPerc()
        {
            decimal pp;
            decimal answer;
            decimal bns;
            //checks inputs, and adds 10 to calculate passive perception.
            Console.WriteLine("Please enter your passive perception skill modifier.");
            pp = Check();
            Console.WriteLine("Please enter any bonus(es) you may have.");
            bns = Check();
            answer = 10 + pp + bns;
            return answer;
        }
        //working input check
        private static decimal Check()
        {
            bool UserInput = true;
            decimal UserNumber = 0;

            while (UserInput)
            {//Parses for number. returns the number if valid, stays looped if not. max input of 6.
                Console.WriteLine("\nPlease enter valid value.\n");
                string UI = Console.ReadLine();
                bool User = decimal.TryParse(UI, out UserNumber);
                if (User && UserNumber >= 0 && (User && UserNumber <= 6))
                {
                    UserInput = false;
                }
                if (User && UserNumber < 0 || User && UserNumber > 6)
                {
                    UserInput = true;
                }
            }
            return UserNumber;
        }
        //working dice rolls
        private static decimal DiceRoll()
        {
            decimal toss;
            decimal roll = 0;
            //Randomly generates numbers with a min possibility of 1, and a max possibility of <13.
            Console.WriteLine("\nPlease enter desired Die: \n");
            Console.WriteLine("d12 = 1, d10 = 2, d8 = 3, d6 = 4, d4 = 5\n");
            toss = Check();
            switch (toss)
            {//all lines break, and then the roll is returned.
                case 1:
                    roll = rnd.Next(1,13);
                    break;
                case 2:
                    roll = rnd.Next(1, 11);
                    break;
                case 3:
                    roll = rnd.Next(1, 9);
                    break;
                case 4:
                    roll = rnd.Next(1, 7);
                    break;
                case 5:
                    roll = rnd.Next(1, 5);
                    break;
            }
            return roll;
        }
    }
}