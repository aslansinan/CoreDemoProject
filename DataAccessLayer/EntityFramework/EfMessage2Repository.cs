using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
{
    public List<Message2> GetInboxWithMessageByWriter(int id)
    {
        using (var c = new Context())
        {
            return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList(); //include eklendi
        }
    }

    public List<Message2> GetSendWithMessageByWriter(int id)
    {
        using (var c = new Context())
        {
            return c.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderId == id).ToList(); //include eklendi
        }
    }
}