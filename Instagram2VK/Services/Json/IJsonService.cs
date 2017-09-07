namespace Instagram2VK.Services.Json
{
    interface IJsonService
    {
        T JsonConvertDeserializeObject<T>(string json);
        T JsonConvertDeserializeObjectWithNull<T>(string json);
    }
}