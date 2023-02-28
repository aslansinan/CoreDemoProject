using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class CommentRepository:IGenericDal<Comment>
{
    public void Insert(Comment t)
    {
        throw new NotImplementedException();
    }

    public void Delete(Comment t)
    {
        throw new NotImplementedException();
    }

    public void Update(Comment t)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetListAll()
    {
        throw new NotImplementedException();
    }

    public Comment GetByID(int id)
    {
        throw new NotImplementedException();
    }
}