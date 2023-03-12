using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class Message2Manager : IMessage2Service
{
    private readonly IMessage2Dal _message2Dal;

    public Message2Manager(IMessage2Dal message2Dal)
    {
        _message2Dal = message2Dal;
    }

    public void TAdd(Message2 t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Message2 t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Message2 t)
    {
        throw new NotImplementedException();
    }

    public List<Message2> GetList()
    {
        return _message2Dal.GetListAll();
    }

    public Message2 TGetById(int id)
    {
        return _message2Dal.GetByID(id);
    }

    public List<Message2> GetInboxListByWriter(int id)
    {
        return _message2Dal.GetListWithMessageByWriter(id);
    }
}