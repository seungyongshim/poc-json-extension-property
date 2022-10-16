using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sample;

public record DtoDictionary(string A, string B)
{
    [JsonExtensionData]
    public IDictionary<string, JsonElement> Extensions { get; init; } = new Dictionary<string, JsonElement>();
}
