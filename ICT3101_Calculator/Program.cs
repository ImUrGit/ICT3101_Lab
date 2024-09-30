using ICT3101_Calculator;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Calculator _calculator = new Calculator();
        FileReader fileReader = new FileReader();
        
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            string numInput1 = "", numInput2 = "";
            double result = 0;
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a valid number: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();
            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a valid number: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tf - Factorial");
            Console.WriteLine("\tt - Calculate Triangle");
            Console.WriteLine("\tc - Calculate Circle");
            Console.WriteLine("\tmtbf - Calculate MTBF");
            Console.WriteLine("\tavailability - Calculate Availability");
            Console.WriteLine("\tmagic - Generate Magic Number from file");
            Console.Write("Your option? ");
            string op = Console.ReadLine();

            try
            {
                if (op == "magic")
                {
                    // Call DoOperation for GenMagicNum and pass the FileReader
                    result = _calculator.DoOperation(cleanNum1, cleanNum2, op, fileReader);
                }
                else
                {
                    result = _calculator.DoOperation(cleanNum1, cleanNum2, op);
                }
                
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else
                {
                    Console.WriteLine("Your result: {0:0.##}\n", result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");
            Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "q") endApp = true;
            Console.WriteLine("\n");
        }
        return;
    }
}
