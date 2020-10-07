using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;


namespace BusinessLayer.Mapping
{
	public class ComputerProfiler : Profile
	{
		public ComputerProfiler()
		{
			CreateMap<Computer, ComputerView>()
				.IncludeBase<IBaseEntity, IBaseModel>()
				.ForMember(model => model.Number, e => e.MapFrom(x => x.Number))
				.ForMember(model => model.IpAddress, e => e.MapFrom(x => x.IpAddress))
				.ForMember(model => model.IdGroup, e => e.MapFrom(x => x.IdGroup));

			CreateMap<ComputerView, Computer>()
				.IncludeBase<IBaseModel, IBaseEntity>()
				.ForMember(model => model.Number, e => e.MapFrom(x => x.Number))
				.ForMember(model => model.IpAddress, e => e.MapFrom(x => x.IpAddress))
				.ForMember(model => model.IdGroup, e => e.MapFrom(x => x.IdGroup))
				.ForMember(model => model.ComputerGroup, e => e.Ignore());
		}
	}
}