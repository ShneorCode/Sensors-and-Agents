using System.Collections.Generic;

public class IranianAgent
{
    private List<string> secretWeaknesses;
    private List<Sensor> attachedSensors;

    public IranianAgent(List<string> weaknesses)
    {
        secretWeaknesses = weaknesses;
        attachedSensors = new List<Sensor>();
    }

    public void AttachSensor(Sensor sensor)
    {
        attachedSensors.Add(sensor);
    }

    public int ActivateSensors()
    {
        int matchCount = 0;
        var uncoveredWeaknesses = new List<string>(secretWeaknesses);

        foreach (Sensor sensor in attachedSensors)
        {
            for (int i = 0; i < uncoveredWeaknesses.Count; i++)
            {
                if (sensor.Activate(uncoveredWeaknesses[i]))
                {
                    matchCount++;
                    uncoveredWeaknesses.RemoveAt(i); 
                    break; 
                }
            }
        }

        return matchCount;
    }


    public int GetWeaknessCount()
    {
        return secretWeaknesses.Count;
    }

    public bool IsExposed()
    {
        return ActivateSensors() >= secretWeaknesses.Count;
    }
}
