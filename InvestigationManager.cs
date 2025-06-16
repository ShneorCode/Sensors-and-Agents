using System;
using System.Collections.Generic;

public class InvestigationManager
{
    private IranianAgent agent;
    private List<Sensor> availableSensors;

    public InvestigationManager()
    {
        agent = new IranianAgent(new List<string> { "Magnet", "Heat", "Magnet" });

        availableSensors = new List<Sensor>
        {
            new Sensor("Laser"),
            new Sensor("Motion"),
            new Sensor("Sound"),
            new Sensor("Magnet"),
            new Sensor("Heat")
        };
    }

    public void Run()
    {
        while (!agent.IsExposed())
        {
            Console.WriteLine();
            Console.WriteLine("Available Sensors:");
            for (int i = 0; i < availableSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableSensors[i].Type}");
            }

            Console.Write("Enter sensor number to attach: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= 1 && choice <= availableSensors.Count)
            {
                Sensor chosenSensor = availableSensors[choice - 1];
                agent.AttachSensor(chosenSensor);

                int matches = agent.ActivateSensors();
                int total = agent.GetWeaknessCount();

                Console.WriteLine($"Matched: {matches}/{total}");

                if (matches >= total)
                {
                    Console.WriteLine("The agent has been exposed!");
                }
                else
                {
                    Console.WriteLine("Not exposed yet. Keep trying.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        Console.WriteLine("Investigation complete.");
    }
}
