using System;

namespace Foundation4_Abstraction
{
    // This class demonstrates Abstraction. 
    // The user only calls ExecuteJump(), while the complex calculations are hidden.
    public class GapEngine
    {
        private string engineModel = "Pag Corp GAP-Drive Mk. IV";
        private int currentFuelLevel = 100;

        // PUBLIC INTERFACE: The only method the main program needs to call.
        // It hides all the complex steps required to make a jump.
        public void ExecuteJump(string origin, string destination)
        {
            Console.WriteLine($"\n--- INITIALIZING {engineModel.ToUpper()} ---");
            Console.WriteLine($"Setting coordinates: {origin} -> {destination}");

            // The complexity is hidden behind these private helper methods
            int distance = CalculateDistance(origin, destination);
            string hazards = ScanForHazards(destination);
            bool spoolSuccess = SpoolDrive(distance);

            if (spoolSuccess)
            {
                Console.WriteLine("\n[STATUS: ABNORMAL PASSAGE OPENED - JUMP SUCCESSFUL]");
                Console.WriteLine($"Arrived safely at: {destination}.");
                Console.WriteLine($"Hazard Warning for this sector: {hazards}");
                Console.WriteLine($"Remaining GAP Fuel: {currentFuelLevel}%");
            }
            else
            {
                Console.WriteLine("\n[STATUS: JUMP ABORTED - INSUFFICIENT VIGOR ENERGY]");
            }
            Console.WriteLine("------------------------------------------------------\n");
        }

        // PRIVATE METHODS: The hidden complexity (Abstraction in action)
        
        private int CalculateDistance(string start, string end)
        {
            Console.WriteLine("Calculating quantum trajectory and spatial folding distance...");
            // Simulating complex navigational math
            Random rnd = new Random();
            return rnd.Next(10, 50); 
        }

        private string ScanForHazards(string destination)
        {
            Console.WriteLine("Scanning destination sector for anomalies...");
            
            // Injecting your worldbuilding lore based on destination
            if (destination == "Binding") 
                return "WARNING: Uncontained Eye-Suckers and Hound-Wings detected on surface.";
            if (destination == "Vidge") 
                return "CRITICAL: Anticyclonic particle storm and rogue Piercers present.";
            if (destination == "Pativ City") 
                return "ALERT: High gravity asteroid field. Potential Stecore encounters in orbit.";
            if (destination == "Nilreb") 
                return "WARNING: Heavy Corvusite presence. Holders of Fate restricted sector.";
            if (destination == "Comet's End") 
                return "ANOMALY: Reality tear detected. Proceed with extreme caution.";
            if (destination == "Zarena")
                return "Clear skies. Enjoy the vacation resorts and avoid the Zilants.";
            
            return "Sector clear. Standard environmental hazards apply.";
        }

        private bool SpoolDrive(int distance)
        {
            Console.WriteLine($"Spooling GAP Engine for {distance} light-year jump...");
            
            // Simulating fuel consumption based on distance
            int fuelRequired = distance; 

            if (currentFuelLevel >= fuelRequired)
            {
                currentFuelLevel -= fuelRequired;
                Console.WriteLine("Power stabilized. Compressing space-time...");
                return true;
            }
            else
            {
                Console.WriteLine("ERROR: Not enough energy to complete the jump.");
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the I.T.S. Artificial Navigation Console.");
            
            GapEngine navComputer = new GapEngine();

            // The main program is incredibly clean because of abstraction.
            // It doesn't need to know how the engine calculates hazards or fuel.
            navComputer.ExecuteJump("Bryantia", "Binding");
            
            // Let's do another jump
            navComputer.ExecuteJump("Binding", "Vidge");
            
            // And a final jump to a heavily guarded planet
            navComputer.ExecuteJump("Vidge", "Nilreb");
            
            // Note: If you run this, you will see the fuel decrease with each jump!
        }
    }
}