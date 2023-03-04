using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class BlogManager:IBlogService
{
    IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }
    public void BlogAdd(Blog blog)
    {
        _blogDal.Insert(blog);
    }

    public void BlogDelete(Blog blog)
    {
        _blogDal.Delete(blog);
    }

    public void BlogUpdate(Blog blog)
    {
        _blogDal.Update(blog);
    }

    public List<Blog> GetList()
    {
        return _blogDal.GetListAll();
    } 

    public Blog GetById(int id)
    {
        return _blogDal.GetByID(id);
    }

    public List<Blog> GetBlogById(int id)
    {
        return _blogDal.GetListAll(x => x.BlogID == id);
    }

    public List<Blog> GetBlogListWithCategory()
    {
        return _blogDal.GetListWithCategory();
    }

    public List<Blog> GetBlogListWithWriter(int id)
    {
        return _blogDal.GetListAll(x => x.WriterID == id);
    }
}