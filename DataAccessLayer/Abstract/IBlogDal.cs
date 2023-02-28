using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IBlogDal
{
    List<Blog> listAllBlog();
    void AddBlog(Blog blog);
    void DeleteBlog(Blog blog);
    void UpdateBlog(Blog blog);
    Blog GetById(int id);
}