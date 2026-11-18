using System;
class NumSys
{
    static void Main()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("|             Welcome to NUMSYS PRO!                       |");
        Console.WriteLine("|            Multi-Base Number System Calculator           |");
        Console.WriteLine("============================================================");
        Console.WriteLine();


        string choice;


        do
        {
            // First step: choosing starting number system base
            int fromBase = 0;
            string fromName = "";
            string guideNum = "";
            string inputBase;


            while (fromBase == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============================================================");
                Console.WriteLine("|STEP 1: What base to CONVERT FROM?                        |");
                Console.WriteLine("|Please choose a number system:                            |");
                Console.WriteLine("============================================================");
                Console.ResetColor();
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.WriteLine("|    [2]     |  |    [8]     |  |    [10]    |  |    [16]    |");
                Console.WriteLine("|   Binary   |  |   Octal    |  |  Decimal   |  | Hexadecimal|");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.Write("Type 2, 8, 10, or 16 and press Enter: ");
                inputBase = Console.ReadLine();
                Console.WriteLine();


                if (inputBase == "2") { fromBase = 2; fromName = "binary"; guideNum = "0 and 1"; }
                else if (inputBase == "8") { fromBase = 8; fromName = "octal"; guideNum = "digits 0 to 7"; }
                else if (inputBase == "10") { fromBase = 10; fromName = "decimal"; guideNum = "digits 0 to 9"; }
                else if (inputBase == "16") { fromBase = 16; fromName = "hexadecimal"; guideNum = "digits 0 to 9 and letters A to F"; }
                else
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|Invalid choice!                                           |");
                    Console.WriteLine("|Please try again and type 2, 8, 10, or 16.                |");
                    Console.WriteLine("============================================================");
                    Console.WriteLine();
                }
            }


            // Second step: choosing what number system base to convert to
            int toBase = 0;
            string toName = "";


            while (toBase == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============================================================");
                Console.WriteLine("|STEP 2: What base to CONVERT TO?                          |");
                Console.WriteLine("|Please choose a number system:                            |");
                Console.WriteLine("============================================================");
                Console.ResetColor();
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.WriteLine("|    [2]     |  |    [8]     |  |    [10]    |  |    [16]    |");
                Console.WriteLine("|   Binary   |  |   Octal    |  |  Decimal   |  |Hexadecimal |");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.Write("Type 2, 8, 10, or 16 and press Enter: ");
                inputBase = Console.ReadLine();
                Console.WriteLine();


                if (inputBase == "2") { toBase = 2; toName = "binary"; }
                else if (inputBase == "8") { toBase = 8; toName = "octal"; }
                else if (inputBase == "10") { toBase = 10; toName = "decimal"; }
                else if (inputBase == "16") { toBase = 16; toName = "hexadecimal"; }
                else
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|Invalid choice!                                           |");
                    Console.WriteLine("|Please type 2, 8, 10, or 16.                              |");
                    Console.WriteLine("============================================================");
                    Console.WriteLine();
                }
            }


            // If the user chooses RETRY
            choice = "r";


            while (choice == "r")
            {
                string inputNum = "";
                long number = 0;
                bool valid = false;


                // Ask for the number until it is valid and display an example
                while (valid == false)
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("Enter a " + fromName + " number");
                    Console.WriteLine("Use only " + guideNum);
                    Console.WriteLine("============================================================");
                    Console.Write("Number: ");
                    inputNum = Console.ReadLine();
                    Console.WriteLine();


                    // Check every digit and build the decimal value
                    valid = true;
                    number = 0;


                    if (inputNum.Length == 0)
                    {
                        valid = false;
                    }


                    for (int i = 0; i < inputNum.Length; i++)
                    {
                        char c = inputNum[i];
                        int digit = -1;


                        // Checks the character's number codes and if the input is too big
                        if (c >= '0' && c <= '9') { digit = c - '0'; }
                        else if (c >= 'A' && c <= 'F') { digit = c - 'A' + 10; }
                        else if (c >= 'a' && c <= 'f') { digit = c - 'a' + 10; }


                        if (digit == -1 || digit >= fromBase)
                        {
                            valid = false;
                        }
                        else if (number > 100000000000000000)
                        {
                            valid = false;
                        }
                        else
                        {
                            number = number * fromBase + digit;
                        }
                    }


                    if (valid == false)
                    {
                        Console.WriteLine("============================================================");
                        Console.WriteLine("|Invalid number!");
                        Console.WriteLine("|A " + fromName + " number can only use");
                        Console.WriteLine("|" + guideNum + ".");
                        Console.WriteLine("|The number must also not be too big.");
                        Console.WriteLine("|Please try again.");
                        Console.WriteLine("============================================================");
                        Console.WriteLine();
                    }
                }


                // Shows the process on how to convert TO DECIMAL
                if (fromBase != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|Convert TO DECIMAL process: (digit x base^position)");
                    Console.WriteLine("============================================================");
                    Console.ResetColor();


                    for (int i = 0; i < inputNum.Length; i++)
                    {
                        char c = inputNum[i];
                        int digit = 0;


                        if (c >= '0' && c <= '9') { digit = c - '0'; }
                        else if (c >= 'A' && c <= 'F') { digit = c - 'A' + 10; }
                        else if (c >= 'a' && c <= 'f') { digit = c - 'a' + 10; }


                        int position = inputNum.Length - 1 - i;


                        // Find base^position by multiplying
                        long place = 1;
                        for (int j = 0; j < position; j++)
                        {
                            place = place * fromBase;
                        }


                        long value = digit * place;
                        Console.WriteLine(c + " x " + fromBase + "^" + position + " = " + value);
                    }


                    Console.WriteLine("|Total = " + number);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("============================================================");
                    Console.ResetColor();
                    Console.WriteLine();
                }


                // Shows the process on how to convert FROM DECIMAL
                string result = "";


                if (toBase == 10)
                {
                    result = "" + number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|FROM DECIMAL (divide by " + toBase + " until the quotient is 0)");
                    Console.WriteLine("============================================================");
                    Console.ResetColor();


                    long temp = number;


                    do
                    {
                        long quotient = temp / toBase;
                        long remainder = temp % toBase;


                        // Remainders 10 to 15 are written as letters A to F
                        string remText = "" + remainder;
                        if (remainder == 10) { remText = "A"; }
                        else if (remainder == 11) { remText = "B"; }
                        else if (remainder == 12) { remText = "C"; }
                        else if (remainder == 13) { remText = "D"; }
                        else if (remainder == 14) { remText = "E"; }
                        else if (remainder == 15) { remText = "F"; }


                        Console.WriteLine(temp + " / " + toBase + " = " + quotient + " remainder " + remText);


                        // Each new remainder goes in front of the result
                        result = remText + result;
                        temp = quotient;
                    } while (temp > 0);


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("|Finally, read the remainders from bottom to top.                   |");
                    Console.WriteLine("============================================================");
                    Console.ResetColor();
                    Console.WriteLine();
                }


                // ---------- Show the result ----------
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("============================================================");
                Console.WriteLine("|Conversion RESULT:");
                Console.WriteLine("|" + inputNum + " (" + fromName + ")");
                Console.WriteLine("|= " + result + " (" + toName + ")");
                Console.WriteLine("============================================================");
                Console.ResetColor();
                Console.WriteLine();


                // Pause so the user can read the process and result first
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.WriteLine();


                // ---------- What next? ----------
                choice = "";


                while (choice != "r" && choice != "n" && choice != "q")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|WHAT'S NEXT, USER?                                        |");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("|Retry     = same bases but new number                     |");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("|New Bases = choose new bases                              |");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|Quit      = exit the program                              |");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("============================================================");

                    // Buttons: Retry = green, New Bases = blue, Quit = red
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+------------+  ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("+------------+  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("+------------+");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|    [R]     |  ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("|    [N]     |  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|    [Q]     |");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("|   Retry    |  ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("| New Bases  |  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|    Quit    |");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+------------+  ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("+------------+  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("+------------+");
                    Console.ResetColor();

                    Console.Write("Type R, N, or Q and press Enter: ");
                    choice = Console.ReadLine();
                    Console.WriteLine();


                    if (choice == "R") { choice = "r"; }
                    if (choice == "N") { choice = "n"; }
                    if (choice == "Q") { choice = "q"; }


                    if (choice != "r" && choice != "n" && choice != "q")
                    {
                        Console.WriteLine("============================================================");
                        Console.WriteLine("|Invalid choice!                                           |");
                        Console.WriteLine("|Please type R, N, or Q.                                   |");
                        Console.WriteLine("============================================================");
                        Console.WriteLine();
                    }
                }
            }
        } while (choice != "q");


        // Goodbye screen
        Console.WriteLine("============================================================");
        Console.WriteLine("|              Thank you for using NumSysPro!              |");
        Console.WriteLine("|                                                          |");
        Console.WriteLine("|                Khalil Louisechatel Rivera                |");
        Console.WriteLine("|                   Semperkin R. Escala                    |");
        Console.WriteLine("|                   Lizeth Ann E. Ebeya                    |");
        Console.WriteLine("============================================================");
    }
}