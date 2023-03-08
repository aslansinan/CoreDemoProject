using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class NewsLetterManager : INewsLetterService
{
    INewsletterDal _newsletterDal;

    public NewsLetterManager(INewsletterDal newsletterDal)
    {
        _newsletterDal = newsletterDal;
    }

    public void TAdd(NewsLetter t)
    {
        _newsletterDal.Insert(t);
    }

    public void TDelete(NewsLetter t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(NewsLetter t)
    {
        throw new NotImplementedException();
    }

    public List<NewsLetter> GetList()
    {
        throw new NotImplementedException();
    }

    public NewsLetter TGetById(int id)
    {
        throw new NotImplementedException();
    }
}