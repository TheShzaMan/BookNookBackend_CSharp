using FullStackAuth_WebAPI.DataTransferObjects;



namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        public List<ReviewWithUserDTO> Reviews { get; set; }

        public double AvgRating { get; set;}

        public bool isFavorite {  get; set;}

    }
}
