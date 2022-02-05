
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Team2.Net.DataEntities
{
	class CategoriesInfo
	{
		[JsonProperty("data")]
		public List<Data> Data { get; set; }
	}
}
