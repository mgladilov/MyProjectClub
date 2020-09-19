using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Model;

namespace BusinessLayer.Mapping
{
	public class ComputerGroupProfiler : Profile
	{
		public ComputerGroupProfiler()
		{
			CreateMap<ComputerGroup, ComputerGroupView>();
			
			CreateMap<ComputerGroupView, ComputerGroup>();
		}
	}
}