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
        _blogDal.Insert(t);
    }

    public List<Blog> GetListWithCategoryByWriterBm(int id)
    {
        return _blogDal.GetListWithCategoryByWriter(id);
    }

    public void TDelete(Blog t)
    {
        _blogDal.Delete(t);
    }

    public void TUpdate(Blog t)
    {
        _blogDal.Update(t);
    }

    public List<Blog> GetList()
    {
        return _blogDal.GetListAll();
    }

    public List<Blog> GetLast3Blog()
    {
        return _blogDal.GetListAll().Take(3).ToList();
    }

    public Blog TGetById(int id)
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