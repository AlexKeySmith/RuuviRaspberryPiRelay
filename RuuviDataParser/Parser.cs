using System;
using System.Runtime.InteropServices;

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

    public static double GetTemperature(byte[] data)
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

    public static double GetTemperatureSpread(byte[] data)
    {

        // Extract temperature bytes (offsets 1-2)
        var temperatureData = data[1..3];

        if (BitConverter.IsLittleEndian) {
            Array.Reverse(temperatureData);
        }

        var rawTemperature = BitConverter.ToInt16(temperatureData,0);


        // Calculate actual temperature
        double temperature = rawTemperature * 0.005;
        return temperature;

    }

    public static double GetTemperatureSpan(byte[] data)
    {

        Span<byte> dataAsSpan = data;

        // Extract temperature bytes (offsets 1-2)
        var temperatureData = dataAsSpan[1..3];

        if (BitConverter.IsLittleEndian) {
            MemoryExtensions.Reverse(temperatureData);
        }
        
        var rawTemperature = MemoryMarshal.AsRef<short>(temperatureData);

        // Calculate actual temperature
        double temperature = rawTemperature * 0.005;
        return temperature;

    }

}
