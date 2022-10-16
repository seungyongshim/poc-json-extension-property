using System;
using Xunit;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Sample.Tests;

public class DtoJsonObjectSpec
{
    [Fact]
    public void JsonExtensionData()
    {
        var rawJson = """
        {
            "A" : "A",
            "B" : "B",
            "C" : "C"
        }
        """;

        var dto = JsonSerializer.Deserialize<DtoJsonObject>(rawJson);

        Assert.Equal("A", dto.A);
        Assert.Equal("B", dto.B);
        if (dto.Extensions.TryGetPropertyValue("C", out var c))
        {
            Assert.Equal("C", c.ToString());
        }
        else
        {
            throw new Exception("not here");
        }
    }

    [Fact]
    public void JsonExtensionDataNull()
    {
        var rawJson = """
        {
            "A" : "A",
            "B" : "B"
        }
        """;

        var dto = JsonSerializer.Deserialize<DtoJsonObject>(rawJson);

        Assert.Equal("A", dto.A);
        Assert.Equal("B", dto.B);

        if (dto.Extensions.TryGetPropertyValue("C", out var c))
        {
            throw new Exception("not here");
        }
    }
}
