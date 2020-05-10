﻿using AutoMapper;
using BLL.Models;
using InternetForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetForum.App_Start
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PostViewModel, PostModel>()
                .ForMember(x => x.AuthorModel, s => s.MapFrom(x => x.AuthorViewModel))
                .ForMember(x => x.CategoryModel, s => s.MapFrom(x => x.CategoryViewModel))
                .ReverseMap();
            CreateMap<AuthorViewModel, AuthorModel>().ReverseMap();
            CreateMap<CommentViewModel, CommentModel>().ReverseMap();
            CreateMap<TagViewModel, TagModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryModel>().ReverseMap();
            CreateMap<PictureViewModel, PictureModel>().ReverseMap();
        }

    }
}