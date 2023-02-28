using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CategoryManager:ICategoryService
{
    private CategoryRepository categoryRepository = new CategoryRepository();
    public void CateoryAdd(Category category)
    {
        throw new NotImplementedException();
    }

    public void CateoryDelete(Category category)
    {
        throw new NotImplementedException();
    }

    public void CateoryUpdate(Category category)
    {
        throw new NotImplementedException();
    }

    public List<Category> GetList()
    {
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }
}