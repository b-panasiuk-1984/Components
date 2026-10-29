namespace PostService.DataAccess;

using PostService.Models;


public interface IPostingRepository
{
    void CreateDb();

    public Posting? GetById(int id);
    public List<Posting> GetList();
    public int Create(Posting posting);
    public void Update(Posting posting);
    public int Delete(int id);
}