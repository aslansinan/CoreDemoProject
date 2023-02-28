using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class IBlogRepository:IBlogDal
{
    public List<Blog> listAllBlog()
    {
        using var c = new Context();
        return c.Blogs.ToList();
    }

    public void AddBlog(Blog blog)
    {
        using var c = new Context();
        c.Add(blog);
        c.SaveChanges();
    }

    public void DeleteBlog(Blog blog)
    {
        using var c = new Context();
        c.Remove(blog);
        c.SaveChanges();
    }

    public void UpdateBlog(Blog blog)
    {
        using var c = new Context();
        c.Update(blog);
        c.SaveChanges();
    }

    public Blog GetById(int id)
    {
        using var c = new Context();
        return c.Blogs.Find(id);
    }
}