using System;
using System.Numerics;
using Shouldly;

namespace RuuviRaspberryPiRelay.RuuviDataParser.UnitTests;

public class UnitTest
{
    const string testData = "0512FC5394C37C0004FFFC040CAC364200CDCBB8334C884F";
    private readonly Payload payload;


    public UnitTest()
    {
        payload = Parser.Parse(Convert.FromHexString(testData));
    }

    [Fact]
    public void ShouldGetDataFormat()
    {
        payload.DataFormat.ShouldBe((byte)5);
    }
    
    [Fact]
    public void ShouldGetTemperature()
    {
        payload.Temperature.ShouldBe(24.3d);
    }


    
    [Fact]
    public void ShouldGetTemperatureSpreader()
    {
        Parser.GetTemperatureSpread(Convert.FromHexString(testData)).ShouldBe(24.3d);
    }



    [Fact]
    public void ShouldGetTemperatureSpan()
    {
        Parser.GetTemperatureSpan(Convert.FromHexString(testData)).ShouldBe(24.3d);
    }



}