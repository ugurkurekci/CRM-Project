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

       return JsonConvert.DeserializeObject<T>(json);

    }

}