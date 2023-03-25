using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class GenericRepository<T>:IGenericDal<T> where T:class
{
    public void Insert(T t)
    {
        using var c = new Context();
        c.Add(t);
        c.SaveChangesAsync();
    }

    public void Delete(T t)
    {
        using var c = new Context();
        c.Remove(t);
        c.SaveChangesAsync();
    }

    public void Update(T t)
    {
        using var c = new Context();
        c.Update(t);
        c.SaveChangesAsync();
    }

    public List<T> GetListAll()
    {
        using var c = new Context();
        return c.Set<T>().ToList();
    }

    public T GetByID(int id)
    {
        using var c = new Context();
        return c.Set<T>().Find(id);
    }

    public List<T> GetListAll(Expression<Func<T, bool>> filter)
    {
        using var c = new Context();
        return c.Set<T>().Where(filter).ToList();
    }
}