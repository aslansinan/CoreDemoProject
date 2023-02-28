using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface ICategoryDal
{
    List<Category> ListAllCategory();
    void AddCategory(Category category);
    void DeleteCategory(Category category);
    void UpdateCategory(Category category);
    Category GetById(int id);
}