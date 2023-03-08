using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class BlogManager : IBlogService
{
    IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }
    public void TAdd(Blog t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Blog t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Blog t)
    {
        throw new NotImplementedException();
    }

    public List<Blog> GetList()
    {
        return _blogDal.GetListAll();
    }

    public List<Blog> GetLast3Blog()
    {
        return _blogDal.GetListAll().Take(3).ToList();
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