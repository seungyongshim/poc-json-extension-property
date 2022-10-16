using System.Collections.Generic;
using System;
using Xunit;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sample.Tests;

public record Dto(string A, string B)
{
    [JsonExtensionData]
    public IDictionary<string, object> Extensions { get; set; } = new Dictionary<string, object>(StringComparer.Ordinal);
}

public class PreludeSpec
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

        var dto = JsonSerializer.Deserialize<Dto>(rawJson);

        Assert.Equal("A", dto.A);
        Assert.Equal("B", dto.B);
        Assert.Equal("C", dto.Extensions["C"].ToString());
    }
}
