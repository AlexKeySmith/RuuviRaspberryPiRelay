using System;
using System.Numerics;
using Shouldly;

namespace RuuviRaspberryPiRelay.RuuviDataParser.UnitTests;

public class UnitTest
{
    const string testData = "0512FC5394C37C0004FFFC040CAC364200CDCBB8334C884F";

    [Fact]
    public void ShouldGetDataFormat()
    {
        var payload = Parser.Parse(Convert.FromHexString(testData));

        payload.DataFormat.ShouldBe((sbyte)5);
    }

    


}