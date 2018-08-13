using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2__Golf_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> swings = new List<string>();
            bool alive = true;
            Console.Clear();
            double z = CourseDistance();
            double remainToTheHole = z;
            Console.WriteLine("Welcome to Walliams Golf Game");
            Console.WriteLine("To start a new game press 1, otherwise press q to quit the game.");
            string Answer = null;
            Answer = Console.ReadLine();
            const string NewGame = ("1");
            const string Quit = ("q");
            int Strokes = 0;
            if (Answer == NewGame)
            {
                Console.WriteLine("Welcome to my golf game!!!");
                Console.WriteLine("To start your first swing of your ball you need to insert the angle (x) between 1 and 90 , after that you need to insert the velocity (y) of your swing ,100 m/s being the max.");
                Console.WriteLine("Good luck !!!");
                Console.WriteLine(" There is a max of strokes you can use depending on how big your course is, usually it's around 1 stroke per 100 meters");

                    double MaxSwings = (z / 100 + 1);
                do
                {


                    Console.WriteLine("The distance of this hole is " + remainToTheHole + "meters long");
                    double x = AngleGiven(); // Player given angel
                    double y = VelocityGiven(); // Players given velocity

                    double AngleInRadians = (Math.PI / 180) * x;
                    double Distance = (Math.Pow(y, 2) / 9.8 * Math.Sin(2 * AngleInRadians));
                    remainToTheHole -= Distance;



                    if (remainToTheHole < 0)
                        remainToTheHole *= -1;
                    Console.WriteLine($"Ball travled {Distance}");
                    swings.Add($"Ball travled {Distance} and {remainToTheHole} left to cup");
                    Console.WriteLine($"Course length after current swing: {remainToTheHole}");

                    if (remainToTheHole <= 0.1)
                    {
                        Console.WriteLine("Congratz you won");
                        Console.ReadKey();
                        break;
                    }
                    else if ( Strokes >MaxSwings)
                            {
                        Console.WriteLine("Game Over, you've used all your Strokes!");
                        break;
                    }

                 
                    Strokes++;
                } while (alive);

                Console.WriteLine("Swings taken: ");
                foreach (var item in swings)
                {
                    Console.WriteLine(item);
                }
            }

            else if (Answer == Quit)
            {
                Console.WriteLine("Thank you for playing, comeback anytime !!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid option, please try again by pressing enter to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static double CourseDistance()
        {
            Random random = new Random();
            double z = random.Next(200, 900);
            // swings man har på sig distance/100 + 1

            return z;
        }
        static double AngleGiven()
        {
            double x = 0;


            while (x <= 1 || x >= 90)
            {
                try
                {
                    Console.Write("Type desired angle (x): ");
                    x = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, please use digits only");
                    Console.ReadKey();

                }
            }
            return x;
        }
        static double VelocityGiven()
        {
            double y = 0;

            while (y < 1 || y > 100)
            {
                try
                {
                    Console.Write("Type desired velocity(y): ");
                    y = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, please use digits only");
                    Console.ReadKey();
                    Console.Clear();
                }
                //Console.WriteLine("y = ");
                //if (y <= 1 || y >= 100)
                //{
                //    string Answerx = null;
                //    Answerx = Console.ReadLine();
                //}
                //else
                //{
                //    Console.WriteLine("Invalid option, please try again by pressing enter to return to the main menu.");
                //    Console.ReadKey();
                //    Console.Clear();
                //}
            }
            return y;
        }
    }
}






