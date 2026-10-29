using PostService.Dtos;
using PostService.Models;
using PostService.CommonTypes;

namespace PostService.Mappings
{
    public class PostingMapper
    {
        public static PostingGetDto ToGetDto(Posting posting)
        {
            return new PostingGetDto
            {
                Id = posting.Id,
                From = posting.From,
                To = posting.To,
                Content = posting.Content,
                DeliveryType = posting.DeliveryType,
                Weight = posting.Weight,
                Width = posting.Width,
                Height = posting.Height,
                Depth = posting.Depth,
                Value = posting.Value ?? 0.0f,
                Price = posting.Price,
                CreatedAt = posting.CreatedAt
            };
        }

        public static Posting ToPosting(PostingPostDTO dto)
        {
            return new Posting
            {
                From = dto.From,
                To = dto.To,
                Content = dto.Content,
                DeliveryType = dto.DeliveryType,
                Weight = dto.Weight,
                Width = dto.Width,
                Height = dto.Height,
                Depth = dto.Depth,
                Value = dto.Value,
                //Price = dto.Price
            };
        }

        public static Posting ToPosting(PostingPutDTO dto)
        {
            return new Posting
            {
                From = dto.From,
                To = dto.To,
                Content = dto.Content,
                DeliveryType = dto.DeliveryType,
                Weight = dto.Weight,
                Width = dto.Width,
                Height = dto.Height,
                Depth = dto.Depth,
                Value = dto.Value,
                Price = dto.Price
            };
        }
    }
}