using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AdminManager : IAdminService
{
    private readonly IAdminDal _adminDal;

    public AdminManager(IAdminDal _adminDal)
    {
        this._adminDal = _adminDal;
    }
    public void TAdd(Admin t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Admin t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Admin t)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetList()
    {
        throw new NotImplementedException();
    }

    public Admin TGetById(int id)
    {
        throw new NotImplementedException();
    }
}