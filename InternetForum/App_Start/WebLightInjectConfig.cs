using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LightInject;
using BLL.Models;

namespace InternetForum.App_Start
{
    public class WebLightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();

            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new WebAutomapperProfile(), new BLLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLLigthInjectConfig.Configuration(container);

            container.Register<IService<PostModel>, PostService>();
            container.Register<IService<AuthorModel>, AuthorService>();
            container.Register<IService<CategoryModel>, CategoryService>();
            container.Register<IService<CommentModel>, CommentService>();
            container.Register<IService<PictureModel>, PictureService>();
            container.Register<IService<TagModel>, TagService>();

            container.EnableMvc();

        }

    }
}