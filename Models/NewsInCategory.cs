using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNestApp.Models
{
    public class NewsInCategory : Base
    {
        [ForeignKey("NewsCategoryID")]
        public int? NewsCategoryID { get; set; }
        public NewsCategory? NewsCategory { get; set; }
        [ForeignKey("NewsID")]
        public int? NewsID { get; set; }
        public News? News { get; set; }
    }
}
