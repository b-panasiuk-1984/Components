using PostService.Models;
using PostService.CommonTypes;
using PostService.DataAccess;

namespace PostService.Services
{
    public interface IPostingService
    {
        Posting Create(Posting newPosting);
        Posting? Update(Posting posting);
        List<Posting> GetAll();
        Posting? Find(int postingId);
        int Delete(int postingId);
    }

    public class PostingService : IPostingService
    {
        // private static List<Posting> _postings = new List<Posting>();
        private readonly IPostingRepository _repository;

        public PostingService(IPostingRepository repository)
        {
            _repository = repository;
        }
        private float getPrice(DeliveryType deliveryType, float weight)
        {
            switch (deliveryType)
            {
                case DeliveryType.Courier:
                    return weight * 2.0f;
                case DeliveryType.ExpressCourier:
                    return weight * 5.0f;
                case DeliveryType.Department:
                    return 20.0f;
                default:
                    return 10.0f;
            }
        }
        public List<Posting> GetAll()
        {
            return _repository.GetList();
        }
        public Posting? Find(int postingId)
        {
            return _repository.GetById(postingId);
        }
        public Posting Create(Posting newPosting)
        {
            newPosting.CreatedAt = DateTime.UtcNow;
            float baseRate = 30f;
            if (newPosting.DeliveryType == DeliveryType.ExpressCourier)
            {
                baseRate = 60f;
            }
            newPosting.Price = baseRate + (newPosting.Weight * 10f);

            var postingId = _repository.Create(newPosting);
            newPosting.Id = postingId;
            return newPosting;
        }

        public Posting? Update(Posting posting)
        {
            var existing = _repository.GetById(posting.Id);
            if (existing == null)
            {
                return null;
            }

            float baseRate = 30f;
            if (posting.DeliveryType == DeliveryType.ExpressCourier)
            {
                baseRate = 60f;
            }
            posting.Price = baseRate + (posting.Weight * 10f);

            _repository.Update(posting);
            return posting;
        }

        public int Delete(int postingId)
        {
            return _repository.Delete(postingId);
        }
    }
}
