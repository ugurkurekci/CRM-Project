using Newtonsoft.Json;

namespace Domain.Extensions;

public static class JsonExtensions
{

    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T ToObject<T>(this string json)
    {

        T? result = JsonConvert.DeserializeObject<T>(json);
        if (result == null)
        {
            throw new Exception($"Could not deserialize {json} to {typeof(T).Name}");
        }
        return result;

    }

}
