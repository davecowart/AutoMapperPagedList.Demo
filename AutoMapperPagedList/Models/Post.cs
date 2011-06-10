using System;

namespace AutoMapperPagedList.Models {
	public class Post {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Timestamp { get; set; }
	}
}