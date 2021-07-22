using System;
using System.Linq;
public class IQ
{

    //Bob is preparing to pass IQ test.The most frequent task in this test is to find out which one of the given numbers differs 
    //from the others.Bob observed that one number usually differs from the others 
    //in evenness.Help Bob — to check his answers, he needs a program that among the given numbers finds one 
    //that is different in evenness, and return a position of this number.
    //! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)

    public static int Test(string numbers)
    {

        int[] arrayInt = numbers.Split(' ').Select(int.Parse).ToArray();

        var oddNums = arrayInt.Where(n => n % 2 != 0);
        var evenNums = arrayInt.Where(n => n % 2 == 0);

        if (oddNums.ToArray().Length > evenNums.ToArray().Length)
        {
            return arrayInt.Select((n, i) => new { num = n, index = i }).First(n => n.num % 2 == 0).index + 1;
        }

        if (oddNums.ToArray().Length < evenNums.ToArray().Length)
        {
            return arrayInt.Select((n, i) => new { num = n, index = i }).First(n => n.num % 2 != 0).index + 1;
        }

        return 0;
    }
}
