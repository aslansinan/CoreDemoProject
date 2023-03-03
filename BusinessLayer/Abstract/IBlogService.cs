using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IBlogService
{
    void BlogAdd(Blog blog);
    void BlogDelete(Blog blog);
    void BlogUpdate(Blog blog);
    List<Blog> GetList();
    Blog GetById(int id);
    List<Blog> GetBlogListWithCategory();
}