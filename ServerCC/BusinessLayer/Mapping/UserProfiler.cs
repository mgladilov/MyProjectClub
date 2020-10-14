using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class UserProfiler : Profile
	{
		public UserProfiler()
		{
			CreateMap<User, UserView>();

			CreateMap<UserView, User>();
		}	
	}
}