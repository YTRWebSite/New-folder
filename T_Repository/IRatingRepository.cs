using Entities;

namespace T_Repository
{
    public interface IRatingRepository
    {
        public Task add_request(Rating rating);
    }
}