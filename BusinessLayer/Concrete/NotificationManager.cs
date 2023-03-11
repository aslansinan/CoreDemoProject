using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;

    public NotificationManager(INotificationDal _notificationDal)
    {
        this._notificationDal = _notificationDal;
    }

    public void TAdd(Notfication t)
    {
        _notificationDal.Insert(t);
    }

    public void TDelete(Notfication t)
    {
       _notificationDal.Update(t);
    }

    public void TUpdate(Notfication t)
    {
       _notificationDal.Delete(t);
    }

    public List<Notfication> GetList()
    {
       return _notificationDal.GetListAll();
    }

    public Notfication TGetById(int id)
    {
        throw new NotImplementedException();
    }
}