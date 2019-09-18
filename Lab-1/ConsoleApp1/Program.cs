using System;
using System.Threading;

public class Program
{
    private static void FirstThread()
    {
        int toSwap = 57384;
        string toSwapAsString = toSwap.ToString();
        int swappedNumber = int.Parse(toSwapAsString.Substring(toSwapAsString.Length - 1) + toSwapAsString.Substring(1, toSwapAsString.Length - 2) + toSwapAsString.Substring(0, 1));
        
        Console.WriteLine(swappedNumber);
    }

    private static void SecondThread()
    {
        string firstString = "gwjwgjgiw";
        string secondString = "wjw";
        string concatenatedString = firstString + secondString + ' ' + (firstString.Length + secondString.Length);

        Console.WriteLine(concatenatedString);
    }

    private static void ThirdThread()
    {
        double number = 1481.38;
        string numberAsString = number.ToString();

        for (int i = 0; i < numberAsString.Length; i++)
        {
            if (numberAsString[i] == '.')
            {
                Console.WriteLine(numberAsString[i + 1]);
                break;
            }
            else
            {

            }
        }
    }

    public static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(FirstThread));
        Thread thread2 = new Thread(new ThreadStart(SecondThread));
        Thread thread3 = new Thread(new ThreadStart(ThirdThread));

        Thread[] threadsArr = { thread1, thread2, thread3 };

        foreach (Thread thread in threadsArr)
        {
            thread.Start();
        }

        _ = Console.ReadKey();
    }
};