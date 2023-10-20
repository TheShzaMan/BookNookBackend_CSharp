using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewWithUserDto

    {      
        public  string UserName { get; set; }

        public double Rating { get; set; }

        public string Text {  get; set; }


    }
}
