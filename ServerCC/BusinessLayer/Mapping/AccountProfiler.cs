using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class AccountProfiler : Profile
	{
		public AccountProfiler()
		{
			CreateMap<Account, AccountView>();

			CreateMap<AccountView, Account>();
		}
	}
}