using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TAdd(About t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(About t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(About t)
    {
        throw new NotImplementedException();
    }

    public List<About> GetList()
    {
        return _aboutDal.GetListAll();
    }

    public About GetById(int id)
    {
        throw new NotImplementedException();
    }
}