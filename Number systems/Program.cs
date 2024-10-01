using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите исходную систему счисления (2-16): ");
            int originalSystem = int.Parse(Console.ReadLine());
            Console.Write("Введите конечную систему счисления (2-16): ");
            int targetSystem = int.Parse(Console.ReadLine());

            if (originalSystem < 2 || originalSystem > 16 || targetSystem < 2 || targetSystem > 16)
            {
                Console.WriteLine("Ошибка: системы счисления должны быть в диапазоне от 2 до 16.");
                return;
            }

            Console.Write("Введите число в исходной системе счисления: ");
            string inputNumber = Console.ReadLine();

            int decimalNumber = Convert.ToInt32(inputNumber, originalSystem);

            string result = Convert.ToString(Math.Abs(decimalNumber), targetSystem).ToUpper();

            if (decimalNumber < 0)
                result = "-" + result;

            Console.WriteLine($"Число в конечной системе счисления ({targetSystem}): {result}");

            if (targetSystem == 2)
            {
                string directCode = GetBinaryWithDirectCode(decimalNumber);
                Console.WriteLine($"Прямой код: {directCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static string GetBinaryWithDirectCode(int number)
    {
        if (number == 0)
            return "0000";

        int bits = Math.Max(4, (int)Math.Ceiling(Math.Log(Math.Abs(number), 2) / 4) * 4);
        string binaryNumber = Convert.ToString(Math.Abs(number), 2).PadLeft(bits, '0'); 

        if (number < 0)
        {
            binaryNumber = "ПК " + binaryNumber.Insert(0, "1").PadRight(bits, '1');
        }
        else
        {
            binaryNumber = binaryNumber.Insert(0, "0").PadRight(bits, '0');
        }

        return binaryNumber;
    }
}
