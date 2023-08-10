using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Humanizer.On;

namespace PlantNestApp.DataTransferObject
{
	public class DataTableAjaxPostModel
	{
		public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }
		public List<Column> columns { get; set; }
		public Search search { get; set; }
		public List<OrderDTO> order { get; set; }
	}
	
	public class Column
	{
		public string data { get; set; }
		public string name { get; set; }
		public bool searchable { get; set; }
		public bool orderable { get; set; }
		public Search search { get; set; }
	}

	public class Search
	{
		public string value { get; set; }
		public string regex { get; set; }
	}

	public class OrderDTO
	{
		public int column { get; set; }
		public string dir { get; set; }
	}
}
