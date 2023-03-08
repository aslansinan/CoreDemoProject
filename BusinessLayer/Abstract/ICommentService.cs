using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICommentService : IGenericService<Comment>
{
    void CommentAdd(Comment comment);
    //void CategoryDelete(Category category);
    //void CategoryUpdate(Category category);
    List<Comment> GetList(int id);
   // Category GetById(int id);
}