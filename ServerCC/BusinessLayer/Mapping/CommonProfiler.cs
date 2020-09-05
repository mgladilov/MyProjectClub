using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class CommonProfiler : Profile
	{
		public CommonProfiler()
		{
			CreateMap<IBaseEntity, IBaseModel>()
				.ForMember(model => model.Id, e => e.MapFrom(x => x.Id))
				.ForMember(model => model.IsDeleted, e => e.MapFrom(x => x.IsDeleted));

			CreateMap<IBaseModel, IBaseEntity>()
				.ForMember(model => model.Id, e => e.MapFrom(x => x.Id))
				.ForMember(model => model.IsDeleted, e => e.MapFrom(x => x.IsDeleted));
		}
	}
}