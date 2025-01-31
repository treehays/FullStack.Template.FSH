﻿using Application.Contracts.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Common.Services;

public class NewtonSoftService : ISerializerService
{
	public T Deserialize<T>(string text)
	{
		return JsonConvert.DeserializeObject<T>(text);
	}

	public string Serialize<T>(T obj)
	{
		return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new List<JsonConverter>
			{
				new StringEnumConverter() { CamelCaseText = true }
			}
		});
	}

	public string Serialize<T>(T obj, Type type)
	{
		return JsonConvert.SerializeObject(obj, type, new());
	}
}
