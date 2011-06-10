using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapperPagedList.Models;
using AutoMapper;

namespace AutoMapperPagedList.Controllers {
	public class PostsController : Controller {
		private AutoMapperPagedListContext context = new AutoMapperPagedListContext();

		//
		// GET: /Posts/

		public ViewResult Index(int page = 0) {
			int pageSize = 10;
			IQueryable<Post> posts = context.Posts.OrderByDescending(p => p.Timestamp).AsQueryable();
			PagedList<PostViewModel> pagedList = posts.ToPagedList<Post, PostViewModel>(page, Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>, pageSize);
			return View(pagedList);
		}

		//
		// GET: /Posts/Details/5

		public ViewResult Details(int id) {
			Post post = context.Posts.Single(x => x.Id == id);
			return View(post);
		}

		//
		// GET: /Posts/Create

		public ActionResult Create() {
			return View();
		}

		//
		// POST: /Posts/Create

		[HttpPost]
		public ActionResult Create(Post post) {
			if (ModelState.IsValid) {
				context.Posts.Add(post);
				context.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(post);
		}

		//
		// GET: /Posts/Edit/5

		public ActionResult Edit(int id) {
			Post post = context.Posts.Single(x => x.Id == id);
			return View(post);
		}

		//
		// POST: /Posts/Edit/5

		[HttpPost]
		public ActionResult Edit(Post post) {
			if (ModelState.IsValid) {
				context.Entry(post).State = EntityState.Modified;
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(post);
		}

		//
		// GET: /Posts/Delete/5

		public ActionResult Delete(int id) {
			Post post = context.Posts.Single(x => x.Id == id);
			return View(post);
		}

		//
		// POST: /Posts/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id) {
			Post post = context.Posts.Single(x => x.Id == id);
			context.Posts.Remove(post);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}