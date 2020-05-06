using AutoMapper;
using BLL.Models;
using InternetForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetForum.App_Start
{
    public class WebAutomapperProfile: Profile
    {
        public WebAutomapperProfile()
        {
           // CreateMap<TovarApiModel, TovarModel>()
           //.ForMember(x => x.CategoryModels, y => y.MapFrom(x => x.CategoryApiModels))
           //.ForMember(x => x.CategoryModelId, y => y.MapFrom(x => x.CategoryApiModelId))
           //.ReverseMap();

           // CreateMap<CategoryApiModel, CategoryModel>().ReverseMap();
            CreateMap<PostViewModel, PostModel>().ReverseMap();
            CreateMap<AuthorViewModel, AuthorModel>().ReverseMap();
            CreateMap<CommentViewModel, CommentModel>().ReverseMap();
            CreateMap<TagViewModel, TagModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryModel>().ReverseMap();
            CreateMap<PictureViewModel, PictureModel>().ReverseMap();
        }

    }
}