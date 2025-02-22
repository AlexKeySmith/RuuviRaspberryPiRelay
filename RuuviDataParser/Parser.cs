using System;

namespace RuuviRaspberryPiRelay.RuuviDataParser;

public static class Parser
{

    public static Payload Parse(byte[] data)
    {

        return new Payload {
            DataFormat =  (byte)data[0],
            Temperature = GetTemperature(data)
        };
    }

    private static double GetTemperature(byte[] data)
    {

        // Extract temperature bytes (offsets 1-2)
        var temperatureData = data.Skip(1).Take(2);

        if (BitConverter.IsLittleEndian) {
            temperatureData = temperatureData.Reverse();
        }

        var rawTemperature = BitConverter.ToInt16(temperatureData.ToArray(),0);


        // Calculate actual temperature
        double temperature = rawTemperature * 0.005;
        return temperature;

    }

}
