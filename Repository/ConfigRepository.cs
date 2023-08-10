using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IConfig : IBaseRepository<ConFig>
	{
	}
	public class ConfigRepository : BaseRepository<ConFig>, IConfig
	{
		public ConfigRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
