﻿using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using InternetForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetForum.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public PostController()
        {
            
        }
        public PostController(IPostService service, ICategoryService categoryservice, IMapper mapper)
        {
            _mapper = mapper;
            _postService = service;
            _categoryService = categoryservice;
        }

        // GET: Post
        public ActionResult Index()
        {
            var allPosts = _postService.GetAll();
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(allPosts);
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var postModel = _postService.GetById(id);
            var postViewModel = _mapper.Map<PostViewModel>(postModel);
            return View(postViewModel);
        }

        public ActionResult PostByCategory(int? id)
        {
            var allPosts = _postService.GetAll();
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(allPosts);
            if (id != null && id != 0)
            {
                posts = posts.Where(x => x.CategoryViewModel.Id == id);
            }

            var allCategories = _categoryService.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            PostCategory postsList = new PostCategory
            {
                Posts = posts,
                Categories = new SelectList(categories, "Id", "Title ")
            };

            return View(postsList);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postModel = _mapper.Map<PostModel>(model);
                _postService.Add(postModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postModel = _mapper.Map<PostModel>(model);
                _postService.Update(postModel);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PostViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _postService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
