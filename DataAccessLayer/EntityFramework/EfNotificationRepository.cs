using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfNotificationRepository : GenericRepository<Notfication>, INotificationDal
{
    
}