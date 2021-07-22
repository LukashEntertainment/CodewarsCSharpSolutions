using System;
using System.Linq;
public class IQ
{
    public static int Test(string numbers)
    {
        var numberIndex = 0;


        int[] arrayInt = numbers.Split(' ').Select(int.Parse).ToArray();

        var oddNums = arrayInt.Where(n => n % 2 != 0);
        var evenNums = arrayInt.Where(n => n % 2 == 0);

        if (oddNums.ToArray().Length > evenNums.ToArray().Length)
        {
            return numberIndex = arrayInt.Select((n, i) => new { num = n, index = i }).First(n => n.num % 2 == 0).index + 1;
        }

        if (oddNums.ToArray().Length < evenNums.ToArray().Length)
        {
            return arrayInt.Select((n, i) => new { num = n, index = i }).First(n => n.num % 2 != 0).index + 1;
        }

        return numberIndex;
    }
}
