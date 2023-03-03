using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CommentManager :ICommentService
{
    private ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }
    public void CommentAdd(Comment comment)
    {
    }

    public List<Comment> GetList(int id)
    {
        return _commentDal.GetListAll(x=> x.BlogID == id);

    }
}