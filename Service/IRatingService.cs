using Entities;

namespace Service
{
    public interface IRatingService
    {
        public  Task add_request(Rating rating);
    }
}