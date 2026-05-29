using System;
using System.Collections.Generic;
using System.IO;

class ScriptureProgram
{
    static void Main(string[] bwArgs)
    {
        List<Scripture> bwLibrary = new List<Scripture>();
        string bwFileName = "scriptures.txt";

        if (!File.Exists(bwFileName))
        {
            File.WriteAllLines(bwFileName, new string[] {
                "Proverbs|3|5|Trust in the Lord with all thine heart; and lean not unto thine own understanding.|6",
                "John|3|16|For God so loved the world, that he gave his only begotten Son...|0"
            });
        }

        string[] bwLines = File.ReadAllLines(bwFileName);
        foreach (string bwLine in bwLines)
        {
            string[] bwParts = bwLine.Split('|');
            if (bwParts.Length == 5)
            {
                string bwBook = bwParts[0];
                int bwChapter = int.Parse(bwParts[1]);
                int bwVerse = int.Parse(bwParts[2]);
                string bwText = bwParts[3];
                int bwEndVerse = int.Parse(bwParts[4]);

                Reference bwReference = (bwEndVerse == 0)
                    ? new Reference(bwBook, bwChapter, bwVerse)
                    : new Reference(bwBook, bwChapter, bwVerse, bwEndVerse);

                bwLibrary.Add(new Scripture(bwReference, bwText));
            }
        }

        if (bwLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found in the library file.");
            return;
        }

        Random bwRand = new Random();
        Scripture bwSelectedScripture = bwLibrary[bwRand.Next(bwLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(bwSelectedScripture.GetDisplayText());
            Console.WriteLine();
            
            if (bwSelectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Great job! All words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("Press Enter to hide words, or type 'quit' to end:");
            string bwInput = Console.ReadLine();

            if (bwInput.ToLower() == "quit")
            {
                break;
            }

            bwSelectedScripture.HideRandomWords(3);
        }
    }
}

public class Scripture
{
    private Reference _bwReference;
    private List<Word> _bwWords = new List<Word>();

    public Scripture(Reference bwReferenceParam, string bwTextParam)
    {
        _bwReference = bwReferenceParam;
        
        string[] bwWordArray = bwTextParam.Split(' ');
        foreach (string bwWordStr in bwWordArray)
        {
            _bwWords.Add(new Word(bwWordStr));
        }
    }

    public void HideRandomWords(int bwNumberToHide)
    {
        Random bwRandomObj = new Random();
        
        int bwVisibleWordsCount = 0;
        foreach (var bwWord in _bwWords)
        {
            if (!bwWord.IsHidden()) bwVisibleWordsCount++;
        }

        int bwActualToHide = Math.Min(bwNumberToHide, bwVisibleWordsCount);
        int bwHiddenCount = 0;

        while (bwHiddenCount < bwActualToHide)
        {
            int bwIndex = bwRandomObj.Next(_bwWords.Count);
            if (!_bwWords[bwIndex].IsHidden())
            {
                _bwWords[bwIndex].Hide();
                bwHiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> bwTextWordsList = new List<string>();
        foreach (var bwWord in _bwWords)
        {
            bwTextWordsList.Add(bwWord.GetText());
        }
        return $"{_bwReference.GetReference()}: {string.Join(" ", bwTextWordsList)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (var bwWord in _bwWords)
        {
            if (!bwWord.IsHidden()) return false;
        }
        return true;
    }
}

public class Reference
{
    private string _bwBook;
    private int _bwChapter;
    private int _bwVerse;
    private int _bwEndVerse;

    public Reference(string bwBookParam, int bwChapterParam, int bwVerseParam)
    {
        _bwBook = bwBookParam;
        _bwChapter = bwChapterParam;
        _bwVerse = bwVerseParam;
        _bwEndVerse = 0;
    }

    public Reference(string bwBookParam, int bwChapterParam, int bwVerseParam, int bwEndVerseParam)
    {
        _bwBook = bwBookParam;
        _bwChapter = bwChapterParam;
        _bwVerse = bwVerseParam;
        _bwEndVerse = bwEndVerseParam;
    }

    public string GetReference()
    {
        if (_bwEndVerse == 0)
        {
            return $"{_bwBook} {_bwChapter}:{_bwVerse}";
        }
        else 
        {
            return $"{_bwBook} {_bwChapter}:{_bwVerse}-{_bwEndVerse}";
        }
    }
}

public class Word
{
    private string _bwText;
    private bool _bwIsHidden;

    public Word(string bwTextParam)
    {
        _bwText = bwTextParam;
        _bwIsHidden = false;
    }

    public void Hide()
    {
        _bwIsHidden = true;
    }

    public bool IsHidden()
    {
        return _bwIsHidden;
    }

    public string GetText()
    {
        if (_bwIsHidden)
        {
            return new string('_', _bwText.Length);
        }
        return _bwText;
    }
}