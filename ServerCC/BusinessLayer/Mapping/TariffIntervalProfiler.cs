using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class TariffIntervalProfiler : Profile
	{
		public TariffIntervalProfiler()
		{
			CreateMap<TariffInterval, TariffIntervalView>();

			CreateMap<TariffIntervalView, TariffInterval>();
		}
	}
}