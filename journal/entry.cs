using System;
using System.Collections.Generic;

public class Entry 
{
    public string _date;
    public string _prompt;
    public string _entry;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_entry}");
        Console.WriteLine($"Entry: {_entry}");
    }
}

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
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
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}