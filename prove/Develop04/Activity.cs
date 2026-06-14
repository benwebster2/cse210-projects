using System;
using System.Threading;

public class Activity
{
    private string _bwName;
    private string _bwDescription;
    protected int _bwDuration;

    public Activity(string name, string description)
    {
        _bwName = name;
        _bwDescription = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_bwName}.\n");
        Console.WriteLine(_bwDescription);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _bwDuration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_bwDuration} seconds of the {_bwName}.");
        ShowSpinner(5);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] bwSpinner = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(bwSpinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= bwSpinner.Length)
            {
                i = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}