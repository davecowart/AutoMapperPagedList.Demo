using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapperPagedList.Models;
using System.Data.Entity.Database;

namespace AutoMapperPagedList {
	public class DBInitializer : DropCreateDatabaseIfModelChanges<AutoMapperPagedListContext> {
		protected override void Seed(AutoMapperPagedListContext context) {
			var posts = Enumerable.Range(0, 400).Select(i => new Post { Id = i, Title = "Post " + i.ToString(), Body = GenerateBody(), Timestamp = DateTime.Now }).ToList();
			posts.ForEach(p => context.Posts.Add(p));
			context.SaveChanges();

			base.Seed(context);
		}

		private string GenerateBody() {
			return "Pork tenderloin pork chop pig, pancetta jowl spare ribs drumstick. Tongue chuck flank, bacon meatloaf turkey corned beef pancetta ball tip hamburger bresaola jerky pork chop ribeye. Turkey ground round sirloin shankle ham pastrami. Bresaola hamburger pork belly sausage fatback. Jowl pastrami tongue corned beef hamburger shoulder salami tri-tip, meatloaf jerky pork belly sausage. Drumstick pork belly tenderloin shankle, ribeye shoulder ham pancetta fatback meatloaf ground round strip steak. Pork loin chuck bacon, meatball beef cow corned beef pork belly flank jowl chicken.";
		}
	}
}