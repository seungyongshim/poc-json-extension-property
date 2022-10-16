using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sample;

public record DtoJsonObject(string A, string B)
{
    [JsonExtensionData]
    public JsonObject Extensions { get; init; } = new JsonObject();
}
