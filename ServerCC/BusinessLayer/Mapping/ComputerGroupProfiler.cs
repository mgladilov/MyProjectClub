using AutoMapper;
using BusinessLayer.Models;

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