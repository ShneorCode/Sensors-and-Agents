using System;
using System.Collections.Generic;

public class InvestigationManager
{
    private IranianAgent agent;
    private List<Sensor> availableSensors;

    public InvestigationManager()
    {
        // יצירת סוכן עם תמהיל חולשות סודי
        List<string> weaknesses = new List<string> { "Thermal", "Thermal" };
        agent = new IranianAgent(weaknesses);

        // יצירת רשימת סנסורים זמינים לשחקן
        availableSensors = new List<Sensor>
        {
            new Sensor("Thermal"),
            new Sensor("Motion")
        };
    }

    public void StartInvestigation()
    {
        Console.WriteLine("Investigation started.");
        Console.WriteLine("Each turn, select a sensor to attach to the agent.");

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

                Console.WriteLine("Sensor attached. Checking for matches...");
                bool exposed = agent.IsExposed();

                if (exposed)
                {
                    Console.WriteLine("The agent has been exposed!");
                }
                else
                {
                    Console.WriteLine("Not exposed yet. Continue investigation.");
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
