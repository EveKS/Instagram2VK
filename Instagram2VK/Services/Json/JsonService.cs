﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.Services.Json
{
    class JsonService : IJsonService
    {
        T IJsonService.JsonConvertDeserializeObjectWithNull<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
            }
            catch
            {
                return default(T);
            }
        }

        T IJsonService.JsonConvertDeserializeObject<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
