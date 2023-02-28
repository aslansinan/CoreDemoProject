using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICategoryService
{
    void CateoryAdd(Category category);
    void CateoryDelete(Category category);
    void CateoryUpdate(Category category);
    List<Category> GetList();
    Category GetById(int id);
}