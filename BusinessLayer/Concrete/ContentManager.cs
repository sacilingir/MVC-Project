using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentdal;

        public ContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }

        public void CategoryUpdate(Content content)
        {
            _contentdal.Update(content);
        }

        public void ContentAdd(Content content)
        {
            _contentdal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentdal.Delete(content);
        }

        public Content GetByID(int id)
        {
           return _contentdal.Get(x => x.ContentID == id);
        }

        public List<Content> GetList()
        {
            return _contentdal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentdal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter()
        {
            return _contentdal.List(x => x.WriterID == 3);
        }
    }
}
