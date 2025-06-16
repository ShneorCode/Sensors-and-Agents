using System.Collections.Generic;

public class IranianAgent
{
    private List<string> requiredSensorTypes;
    private List<Sensor> attachedSensors;

    public IranianAgent(List<string> requiredTypes)
    {
        requiredSensorTypes = requiredTypes;
        attachedSensors = new List<Sensor>();
    }

    public void AttachSensor(Sensor sensor)
    {
        attachedSensors.Add(sensor);
    }

    public bool IsExposed()
    {
        int correctCount = 0;

        foreach (Sensor sensor in attachedSensors)
        {
            foreach (string weakness in requiredSensorTypes)
            {
                if (sensor.Activate(weakness))
                {
                    correctCount++;
                    break;
                }
            }
        }

        if (correctCount >= requiredSensorTypes.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
