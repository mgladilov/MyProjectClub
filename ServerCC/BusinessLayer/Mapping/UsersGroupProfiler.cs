using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class UsersGroupProfiler : Profile
	{
		public UsersGroupProfiler()
		{
			CreateMap<UsersGroup, UsersGroupView>();
			CreateMap<UsersGroupView, UsersGroup>();
		}
	}
}