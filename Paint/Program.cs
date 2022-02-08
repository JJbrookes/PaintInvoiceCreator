
using System;

namespace PaintCostCalculator
{
    class program
    {
        static void Main(String[] args)
        {
            bool isDone = false;
            do
            {
                List<string> questions = new List<string>();
                questions.Add("How many walls do you have: "); //0
                questions.Add("What is the height of wall "); 
                questions.Add("What is the width of wall ");
                questions.Add("How long did it take to complete the job (Hours): ");
                questions.Add("How Much do you want to charge per hour: £");
                questions.Add("How much tax do you charge: ");
                questions.Add("What type of paint are you using? (Enter 1 for Matte, 2 for Satin, 3 for Semi-gloss and 4 for High-gloss)");

                int AmountofWalls = UserInputAndVaildInt(questions[0]);
                List<wall> walls = new List<wall>(AmountofWalls);
                for (int i = 0; i < AmountofWalls; i++)
                {
                    walls.Add(new wall());
                }

                int WallNumber = 1;
                float TotalArea = 0;
                foreach (wall w in walls)
                {

                    w.width = UserInputAndVaildFloat(questions[1]+ WallNumber+ " (In Meters): ");
                    w.height  = UserInputAndVaildFloat(questions[2] + WallNumber + " (In Meters): ");
                    TotalArea += w.area;
                    WallNumber++;

                }
                int TotalLiters = (int)Math.Ceiling(TotalArea) / 10; //This is based on a coverage of 10m² per litre of paint. 

               // float TotalTinsUsed = UserInputAndVaildFloat(questions[0]);
                float CostPerlitres = UserInputAndVaildInt(questions[6]);
                switch (CostPerlitres)
                {
                    case 1:
                        CostPerlitres = 2.99f;
                        break;
                    case 2:
                        CostPerlitres = 3.89f;
                        break;
                    case 3:
                        CostPerlitres = 4.99f;
                        break;
                    case 4:
                        CostPerlitres = 5.99f;
                        break;
                }
                float JobLengthHours = UserInputAndVaildFloat(questions[3]);
                float HourlyRate = UserInputAndVaildFloat(questions[4]);
                float TaxRate = UserInputAndVaildFloat(questions[5]);

                double workingTotal = ((TotalLiters * CostPerlitres) + (JobLengthHours * HourlyRate));
                if (workingTotal >= 500)
                {
                    Console.WriteLine("10% Discount Given");
                    double discount = workingTotal * 0.1;
                    workingTotal = workingTotal - discount;
                }

                double tax = (workingTotal) * (TaxRate / 100);
                double ChargeCustomer = workingTotal + tax;
                Console.WriteLine("Charge Customer: £" + ChargeCustomer.ToString("0.00"));

                Console.Write("Exit(0) Or Clear(1) or Countinue(Enter): ");
                string checkDone = Console.ReadLine();
                switch (checkDone) 
                {
                    case "0":
                        Console.WriteLine("Exiting...");
                        isDone = true;
                        break;
                    case "1":
                        Console.Clear();
                        break;
                    default:
             
                        break;
                }                 
            } while (!isDone);
        }

        private static float UserInputAndVaildFloat(string Message)
        {
            float UserValue = 0;
            Console.Write(Message);
            while ((!float.TryParse(Console.ReadLine(), out UserValue)) || (UserValue == 0))
            {
                Console.WriteLine("Not a valid number");
                Console.Write(Message);
            }
            return UserValue;
        }

        private static int UserInputAndVaildInt(string Message)
        {
            int UserValue = 0;
            Console.Write(Message);
            while (!int.TryParse(Console.ReadLine(), out UserValue))
            {
                Console.WriteLine("Not a valid number");
            }
            return UserValue;

        }
    }

    class wall
    {
        float WidthMeters;
        float HeightMeters;

        public float width   // property
        {
            get { return WidthMeters; }   // get method
            set { WidthMeters = value; }  // set method
        }
        public float height // property
        {
            get { return HeightMeters; }   // get method
            set { HeightMeters = value; }  // set method
        }
        public float area
        {
            get { return WidthMeters * HeightMeters ; }
        }
    }

}

