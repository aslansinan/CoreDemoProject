using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CategoryManager:ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public void CategoryAdd(Category category)
    {
        _categoryDal.Insert(category);
    }

    public void CategoryDelete(Category category)
    {
        _categoryDal.Delete(category);
    }

    public void CategoryUpdate(Category category)
    {
        _categoryDal.Update(category);
    }

    public List<Category> GetList()
    {
        return _categoryDal.GetListAll();
    }

    public Category GetById(int id)
    {
        return _categoryDal.GetByID(id);
    }
}