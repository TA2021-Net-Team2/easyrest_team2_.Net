using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team2.Net.DataEntities
{
	public class LoginInfo
	{
		[JsonProperty("data")]
		public List<Data> Data { get; set; }
	}
}
