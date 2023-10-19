namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewWithUserDto

    {      
        public  UserForDisplayDto User { get; set; }

        public double Rating { get; set; }

        public string Text {  get; set; }


    }
}
