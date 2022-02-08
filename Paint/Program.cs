
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
                questions.Add("How many tins of paint did you use: ");
                questions.Add("How much did each tin cost: £");
                questions.Add("How long did it take to complete the job (Hours): ");
                questions.Add("How Much do you want to charge per hour: £");
                questions.Add("How much tax do you charge: ");
                questions.Add("What type of paint are you using? (Enter 1 for Matte, 2 for Satin, 3 for Semi-gloss and 4 for High-gloss)");

                float TotalTinsUsed = UserInputAndVaildFloat(questions[0]);
                float CostPerTin = UserInputAndVaildInt(questions[5]);
                switch (CostPerTin)
                {
                    case 1:
                        CostPerTin = 2.99f;
                        break;
                    case 2:
                        CostPerTin = 3.89f;
                        break;
                    case 3:
                        CostPerTin = 4.99f;
                        break;
                    case 4:
                        CostPerTin = 5.99f;
                        break;
                }
                float JobLengthHours = UserInputAndVaildFloat(questions[2]);
                float HourlyRate = UserInputAndVaildFloat(questions[3]);
                float TaxRate = UserInputAndVaildFloat(questions[4]);

                double workingTotal = ((TotalTinsUsed * CostPerTin) + (JobLengthHours * HourlyRate));
                if (workingTotal >= 500)
                {
                    Console.WriteLine("10% Discount Given");
                    double discount = workingTotal * 0.1;
                    workingTotal = workingTotal - discount;
                }
                double tax = (workingTotal) * (TaxRate / 100);
                double ChargeCustomer = workingTotal + tax;
                Console.WriteLine("Charge Customer: £" + ChargeCustomer.ToString("0.00"));

                Console.Write("Exit(0) Or Clear(1) or Countinue(1): ");
                string checkDone = Console.ReadLine();
                switch (checkDone) 
                {
                    case "0":
                        Console.WriteLine("Exiting...");
                        isDone = true;
                        break;
                    default:
                        Console.Clear();
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
}

