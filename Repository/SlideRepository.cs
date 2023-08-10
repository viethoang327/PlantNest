using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ISlide : IBaseRepository<Slide>
	{
	}
	public class SlideRepository : BaseRepository<Slide>, ISlide
	{
		public SlideRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
