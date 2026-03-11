using Newtonsoft.Json;
using UnityEngine;

public static class JsonFormatter
{
    public static string ToJson<T>(T obj, bool pretty = false) {
        return JsonConvert.SerializeObject(obj, pretty ? Formatting.Indented : Formatting.None);
    }

    public static T FromJson<T>(string json) {
        return JsonConvert.DeserializeObject<T>(json);
    }
}
