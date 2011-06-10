using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperPagedList.Models {
	public class PostViewModel {
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime Timestamp { get; set; }
	}
}