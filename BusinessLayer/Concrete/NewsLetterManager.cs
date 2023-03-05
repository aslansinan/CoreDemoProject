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


    public void NewsLetterAdd(NewsLetter newsLetter)
    {
        _newsletterDal.Insert(newsLetter);
    }
}