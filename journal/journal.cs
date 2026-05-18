using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

public class Journal
{
    public List<Entry> bwEntries = new List<Entry>();

    public void AddEntry(Entry bwEntry)
    {
        bwEntries.Add(bwEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry bwEntry in bwEntries)
        {
            bwEntry.Display();
        }
    }

    public void SaveToFile(string bwFileName)
    {
        using (StreamWriter writer = new StreamWriter(bwFileName))
        {
            foreach (Entry bwEntry in bwEntries)
            {
                writer.WriteLine($"Date: {bwEntry.bwDate} - Prompt: {bwEntry.bwPrompt}");
            }
        }
        Console.WriteLine($"Journal saved to {bwFileName}");
    }

    public void LoadFromFile(string bwFileName)
    {
        bwEntries.Clear();

        if (File.Exists(bwFileName))
        {
            using (StreamReader bwReader = new StreamReader(bwFileName))
            {
                string bwLine;
                while ((bwLine = bwReader.ReadLine()) != null)
                {
                    string[] bwParts = bwLine.Split(new string[] { " - Prompt: " }, StringSplitOptions.None);
                    if (bwParts.Length == 2)
                    {
                        Entry bwEntry = new Entry();
                        bwEntry.bwDate = bwParts[0].Replace("Date: ", "").Trim();
                        bwEntry.bwPrompt = bwParts[1].Trim();
                        bwEntries.Add(bwEntry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {bwFileName}");
        }
        else
        {
            Console.WriteLine($"File {bwFileName} not found.");
        }

    }
}

