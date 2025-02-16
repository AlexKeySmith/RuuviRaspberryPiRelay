namespace RuuviRaspberryPiRelay.RuuviDataParser;

public static class Parser
{

    public static Payload Parse(byte[] data)
    {

        return new Payload {
            DataFormat =  (sbyte)data[0]
        };
    }

}
