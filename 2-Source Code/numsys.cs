using System;
class numsys
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
            int frombase = 0;
            string fromname = "";
            string guidenum = "";
            string inputbase;


            while (frombase == 0)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("|STEP 1: What base to CONVERT FROM?                        |");
                Console.WriteLine("|Please choose a number system:                            |");
                Console.WriteLine("============================================================");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.WriteLine("|    [2]     |  |    [8]     |  |    [10]    |  |    [16]    |");
                Console.WriteLine("|   Binary   |  |   Octal    |  |  Decimal   |  | Hexadecimal|");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.Write("Type 2, 8, 10, or 16 and press Enter: ");
                inputbase = Console.ReadLine();
                Console.WriteLine();


                if (inputbase == "2") { frombase = 2; fromname = "binary"; guidenum = "0 and 1"; }
                else if (inputbase == "8") { frombase = 8; fromname = "octal"; guidenum = "digits 0 to 7"; }
                else if (inputbase == "10") { frombase = 10; fromname = "decimal"; guidenum = "digits 0 to 9"; }
                else if (inputbase == "16") { frombase = 16; fromname = "hexadecimal"; guidenum = "digits 0 to 9 and letters A to F"; }
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
            int tobase = 0;
            string toname = "";


            while (tobase == 0)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("|STEP 2: What base to CONVERT TO?                          |");
                Console.WriteLine("|Please choose a number system:                            |");
                Console.WriteLine("============================================================");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.WriteLine("|    [2]     |  |    [8]     |  |    [10]    |  |    [16]    |");
                Console.WriteLine("|   Binary   |  |   Octal    |  |  Decimal   |  |Hexadecimal |");
                Console.WriteLine("+------------+  +------------+  +------------+  +------------+");
                Console.Write("Type 2, 8, 10, or 16 and press Enter: ");
                inputbase = Console.ReadLine();
                Console.WriteLine();


                if (inputbase == "2") { tobase = 2; toname = "binary"; }
                else if (inputbase == "8") { tobase = 8; toname = "octal"; }
                else if (inputbase == "10") { tobase = 10; toname = "decimal"; }
                else if (inputbase == "16") { tobase = 16; toname = "hexadecimal"; }
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
                string inputnum = "";
                long number = 0;
                bool valid = false;


                // Ask for the number until it is valid and display an example
                while (valid == false)
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("Enter a " + fromname + " number");
                    Console.WriteLine("Use only " + guidenum);
                    Console.WriteLine("============================================================");
                    Console.Write("Number: ");
                    inputnum = Console.ReadLine();
                    Console.WriteLine();


                    // Check every digit and build the decimal value
                    valid = true;
                    number = 0;


                    if (inputnum.Length == 0)
                    {
                        valid = false;
                    }


                    for (int i = 0; i < inputnum.Length; i++)
                    {
                        char c = inputnum[i];
                        int digit = -1;


                        // Checks the character's number codes and if the input is too big
                        if (c >= '0' && c <= '9') { digit = c - '0'; }
                        else if (c >= 'A' && c <= 'F') { digit = c - 'A' + 10; }
                        else if (c >= 'a' && c <= 'f') { digit = c - 'a' + 10; }


                        if (digit == -1 || digit >= frombase)
                        {
                            valid = false;
                        }
                        else if (number > 100000000000000000)
                        {
                            valid = false;
                        }
                        else
                        {
                            number = number * frombase + digit;
                        }
                    }


                    if (valid == false)
                    {
                        Console.WriteLine("============================================================");
                        Console.WriteLine("|Invalid number!");
                        Console.WriteLine("|A " + fromname + " number can only use");
                        Console.WriteLine("|" + guidenum + ".");
                        Console.WriteLine("|The number must also not be too big.");
                        Console.WriteLine("|Please try again.");
                        Console.WriteLine("============================================================");
                        Console.WriteLine();
                    }
                }


                // Shows the process on how to convert TO DECIMAL
                if (frombase != 10)
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|Convert TO DECIMAL process: (digit x base^position)");
                    Console.WriteLine("============================================================");


                    for (int i = 0; i < inputnum.Length; i++)
                    {
                        char c = inputnum[i];
                        int digit = 0;


                        if (c >= '0' && c <= '9') { digit = c - '0'; }
                        else if (c >= 'A' && c <= 'F') { digit = c - 'A' + 10; }
                        else if (c >= 'a' && c <= 'f') { digit = c - 'a' + 10; }


                        int position = inputnum.Length - 1 - i;


                        // Find base^position by multiplying
                        long place = 1;
                        for (int j = 0; j < position; j++)
                        {
                            place = place * frombase;
                        }


                        long value = digit * place;
                        Console.WriteLine(c + " x " + frombase + "^" + position + " = " + value);
                    }


                    Console.WriteLine("|Total = " + number);
                    Console.WriteLine("============================================================");
                    Console.WriteLine();
                }


                // Shows the process on how to convert FROM DECIMAL
                string result = "";


                if (tobase == 10)
                {
                    result = "" + number;
                }
                else
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|FROM DECIMAL (divide by " + tobase + " until the quotient is 0)");
                    Console.WriteLine("============================================================");


                    long temp = number;


                    do
                    {
                        long quotient = temp / tobase;
                        long remainder = temp % tobase;


                        // Remainders 10 to 15 are written as letters A to F
                        string remtext = "" + remainder;
                        if (remainder == 10) { remtext = "A"; }
                        else if (remainder == 11) { remtext = "B"; }
                        else if (remainder == 12) { remtext = "C"; }
                        else if (remainder == 13) { remtext = "D"; }
                        else if (remainder == 14) { remtext = "E"; }
                        else if (remainder == 15) { remtext = "F"; }


                        Console.WriteLine(temp + " / " + tobase + " = " + quotient + " remainder " + remtext);


                        // Each new remainder goes in front of the result
                        result = remtext + result;
                        temp = quotient;
                    } while (temp > 0);


                    Console.WriteLine("|Finally, read the remainders from bottom to top.                   |");
                    Console.WriteLine("============================================================");
                    Console.WriteLine();
                }


                // ---------- Show the result ----------
                Console.WriteLine("============================================================");
                Console.WriteLine("|Conversion RESULT:");
                Console.WriteLine("|" + inputnum + " (" + fromname + ")");
                Console.WriteLine("|= " + result + " (" + toname + ")");
                Console.WriteLine("============================================================");
                Console.WriteLine();


                // ---------- What next? ----------
                choice = "";


                while (choice != "r" && choice != "n" && choice != "q")
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("|WHAT'S NEXT, USER?                                        |");
                    Console.WriteLine("|Retry     = same bases but new number                     |");
                    Console.WriteLine("|New Bases = choose new bases                              |");
                    Console.WriteLine("|Quit      = exit the program                              |");
                    Console.WriteLine("============================================================");
                    Console.WriteLine("+------------+  +------------+  +------------+");
                    Console.WriteLine("|    [R]     |  |    [N]     |  |    [Q]     |");
                    Console.WriteLine("|   Retry    |  | New Bases  |  |    Quit    |");
                    Console.WriteLine("+------------+  +------------+  +------------+");
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