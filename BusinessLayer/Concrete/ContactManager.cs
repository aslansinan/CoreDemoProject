using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactManager : IContactService
{
    IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {   
        _contactDal = contactDal;
    }

    public void TAdd(Contact t)
    {
        _contactDal.Insert(t);
    }

    public void TDelete(Contact t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Contact t)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetList()
    {
        throw new NotImplementedException();
    }

    public Contact TGetById(int id)
    {
        throw new NotImplementedException();
    }
    
}