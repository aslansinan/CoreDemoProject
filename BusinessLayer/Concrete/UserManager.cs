using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class UserManager : IUserService
{
    public readonly IUserDal _UserDal;

    public UserManager(IUserDal userDal)
    {
        _UserDal = userDal;
    }

    public void TAdd(AppUser t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(AppUser t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(AppUser t)
    {
        _UserDal.Update(t);
    }

    public List<AppUser> GetList()
    {
        throw new NotImplementedException();
    }

    public AppUser TGetById(int id)
    {
       return _UserDal.GetByID(id);
    }
}