using System;

class Dossier
{
    private string bwName;
    private int bwThreatLevel;
    private string bwAllegiance;
    private string bwProfileSummary;

    public Dossier(string bwCharName, int bwCharThreat, string bwCharAllegiance, string bwCharBio)
    {
        bwName = bwCharName;
        SetThreatDirectly(bwCharThreat);
        bwAllegiance = bwCharAllegiance;
        bwProfileSummary = bwCharBio;
    }

    private void SetThreatDirectly(int bwValue)
    {
        if (bwValue >= 1 && bwValue <= 10)
        {
            bwThreatLevel = bwValue;
        }
        else
        {
            bwThreatLevel = 1;
        }
    }

    public string GetName()
    {
        return bwName;
    }

    public void ModifyThreatLevel(int bwNewThreat, string bwSecurityToken)
    {
        if (bwSecurityToken == "CONFERENCE-ALPHA-9")
        {
            SetThreatDirectly(bwNewThreat);
            Console.WriteLine($"\n[AUTHORIZED] Threat rating for {bwName} altered to {bwThreatLevel}.");
        }
        else
        {
            Console.WriteLine("\n[DENIED] Invalid security encryption token.");
        }
    }

    public void RenderDossierData()
    {
        Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"IDENTIFIER: {bwName}");
        Console.WriteLine($"THREAT LEVEL: {bwThreatLevel}/10");
        Console.WriteLine($"ALLEGIANCE: {bwAllegiance}");
        Console.WriteLine($"HISTORICAL RECORD: {bwProfileSummary}");
        Console.WriteLine("---------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dossier bwGraceDossier = new Dossier("Grace Summit", 8, "Independent (Former Conference)", "Enlisted at 16. Survived brutal Starlight campaigns. Was believed to have died in combat, but secretly escaped. Now a shadow-hunter, she is one of the most killed fighters in the galaxy.");
        Dossier bwScalDossier = new Dossier("Scal Brines", 9, "Rogue Corvusite Hunter", "True name Sarent Ne'hour, the Crowkiller. Brainwashed by Reap Cycle when he was a child, he broke free of their control and vowed to put an end to the Reap Cycle and all who are a part of it.");
        Dossier bwWinterDossier = new Dossier("Winter Ecken", 4, "Forager Crew / Ex-AVIAR", "Enslaved on Binding by AVIAR corp, Winter uses custom made vison technology after being blinded by one of Binding's abominations. Not only is she a skilled pilot, but is a capable mechanic and firefighter.");
        Dossier bwZekeDossier = new Dossier("ZK-33", 6, "Paladin Doctor", "Second-generation robotic nurse created by Creteroot. One of the only remaining units on Vidge after the Collapse, ZK-33 searches for survivors and tries to protect the lives around him.");
        Dossier bwIndraDossier = new Dossier("Reapmaster Indra", 10, "Rebuilt Reap Cycle Leader", "The Reap Cycle's leader, Indra was known for her brutality and intense fighting style. She has been the sole reason as to why the Reap Cycle continues and wants to bring them back to their former power.");
        
        string bwActiveChoice = "";

        while (bwActiveChoice != "7")
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine(" CAMILLE NEWPORT'S INTEL ARCHIVE ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Inspect Grace Summit");
            Console.WriteLine("2. Inspect Scal Brines");
            Console.WriteLine("3. Inspect Winter Ecken");
            Console.WriteLine("4. Inspect ZK-33 (Zeke)");
            Console.WriteLine("5. Inspect Reapmaster Indra");
            Console.WriteLine("6. Override Threat Assessment Data");
            Console.WriteLine("7. Log Out");
            Console.Write("Select operations index: ");
            bwActiveChoice = Console.ReadLine();

            if (bwActiveChoice == "1")
            {
                bwGraceDossier.RenderDossierData();
            }
            else if (bwActiveChoice == "2")
            {
                bwScalDossier.RenderDossierData();
            }
            else if (bwActiveChoice == "3")
            {
                bwWinterDossier.RenderDossierData();
            }
            else if (bwActiveChoice == "4")
            {
                bwZekeDossier.RenderDossierData();
            }
            else if (bwActiveChoice == "5")
            {
                bwIndraDossier.RenderDossierData();
            }
            else if (bwActiveChoice == "6")
            {
                Console.WriteLine("\nSelect Record to Alter:\n1. Grace\n2. Scal\n3. Winter\n4. ZK-33\n5. Indra");
                string bwTargetRecord = Console.ReadLine();
                Console.Write("Enter updated rating value (1-10): ");
                
                int bwNewRating;
                bool bwParseSuccess = int.TryParse(Console.ReadLine(), out bwNewRating);

                if (bwParseSuccess)
                {
                    Console.Write("Input Camille's bypass credential: ");
                    string bwTokenInput = Console.ReadLine();

                    if (bwTargetRecord == "1") bwGraceDossier.ModifyThreatLevel(bwNewRating, bwTokenInput);
                    else if (bwTargetRecord == "2") bwScalDossier.ModifyThreatLevel(bwNewRating, bwTokenInput);
                    else if (bwTargetRecord == "3") bwWinterDossier.ModifyThreatLevel(bwNewRating, bwTokenInput);
                    else if (bwTargetRecord == "4") bwZekeDossier.ModifyThreatLevel(bwNewRating, bwTokenInput);
                    else if (bwTargetRecord == "5") bwIndraDossier.ModifyThreatLevel(bwNewRating, bwTokenInput);
                }
                else
                {
                    Console.WriteLine("\n[ERROR] Threat rating must be a valid integer numeric value.");
                }
            }
        }
    }
}