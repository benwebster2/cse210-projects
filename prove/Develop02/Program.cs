using System;

string filename = "myFile.txt"; 
string[] lines = System.10.File.ReadAllLines(filename);

using (StreamWriter outputFile = new StreamWriter(filename))
{
    outputFile.WriteLine("Why couldn't the teenager watch the pirate movie?");

    string funny = "Punchline";
    outputFile.WriteLine("Because it was rated Arghh!");
}

foreach (string line in lines)
{
    string[] parts = line.Split(",");

    string firstName = parts(0);
    string lastName = parts(1);
}