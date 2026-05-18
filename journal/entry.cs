using System;
using System.Collections.Generic;

public class Entry 
{
    public string bwDate;
    public string bwPrompt;
    public string bwEntryText;

    public void Display()
    {
        Console.WriteLine($"Date: {bwDate} - Prompt: {bwPrompt}");
        Console.WriteLine($"{bwEntryText}");
        Console.WriteLine($"Entry: {bwEntryText}");
    }
}

public class PromptGenerator
{
    private List<string> bwPrompts;

    public PromptGenerator()
    {
        bwPrompts = new List<string>
        {
            "Did I have fun today?",
            "What part about today did I not hate?",
            "What did I learn today?",
            "What is something I'm actually looking forward to?",
            "If I could have done anything done differently today, what would it have been?",
            "How did I make the world a better place today?",
            "What am I grateful for today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random bwRandom = new Random();
        int bwIndex = bwRandom.Next(bwPrompts.Count);
        return bwPrompts[bwIndex];
    }
}