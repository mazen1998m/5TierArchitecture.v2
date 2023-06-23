using Newtonsoft.Json;

namespace App.web.Services.JsonServices;

static class ReadJson
{

    public static TType Deserialize<TType>(string filePath)
    {
        // Read the contents of the file
        string json = File.ReadAllText(filePath);

        // Deserialize the JSON string
        return JsonConvert.DeserializeObject<TType>(json)!;
    }
}