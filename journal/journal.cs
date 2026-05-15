using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"Date: {entry._date} - Prompt: {entry._prompt}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { " - Prompt: " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        Entry entry = new Entry();
                        entry._date = parts[0].Replace("Date: ", "").Trim();
                        entry._prompt = parts[1].Trim();
                        _entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.");
        }

    }
}

