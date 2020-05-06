using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService : ForumService<TagModel, Tag>, IService<TagModel>
    {
        public readonly IMapper _mapper;

        public TagService(IRepository<Tag> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override TagModel Map(Tag model)
        {
            return _mapper.Map<TagModel>(model);
        }

        public override Tag Map(TagModel tModel)
        {
            return _mapper.Map<Tag>(tModel);
        }

        public override IEnumerable<TagModel> Map(IList<Tag> comments)
        {
            return _mapper.Map<IEnumerable<TagModel>>(comments);
        }

        public override IEnumerable<Tag> Map(IList<TagModel> commentsModel)
        {
            return _mapper.Map<IEnumerable<Tag>>(commentsModel);
        }
    }
}
