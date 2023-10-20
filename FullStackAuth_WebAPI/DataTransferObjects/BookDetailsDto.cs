using FullStackAuth_WebAPI.DataTransferObjects;



namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {

        public double AvgRating { get; set;}

        public bool isFavorite {  get; set;}

        public List<ReviewWithUserDto> Reviews { get; set; }
    }
}
