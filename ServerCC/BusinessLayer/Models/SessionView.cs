using System;
using Newtonsoft.Json;

namespace BusinessLayer.Models
{
	public class SessionView : BaseModel
	{
		public int IdComp { get; set; }

		public int IdTarif { get; set; }

		public int IdClients { get; set; }

		public DateTime Start { get; set; }

		public DateTime Stop { get; set; }

		public bool IsPacket { get; set; }

		public int IdOperator { get; set; }

		public string AdditionalInformationJSON
		{
			get => JsonConvert.SerializeObject(AdditionalInformation, Formatting.Indented, new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
			set => AdditionalInformation = JsonConvert.DeserializeObject<AdditionalSession>(value ?? "", new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore});
		}

		private AdditionalSession _additionalInformation;

		public AdditionalSession AdditionalInformation
		{
			get => _additionalInformation ?? (_additionalInformation = new AdditionalSession());
			set => _additionalInformation = value;
		}

		[JsonObject]
		public class AdditionalSession
		{
			public int IdSessionsAdd { get; set; }

			public int ActionType { get; set; }

			public DateTime Moment { get; set; }

			public float Summa { get; set; }
		}
	}
}