using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;

namespace Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _IRatingRepository;
        public RatingService(IRatingRepository RatingRepository)
        {
            _IRatingRepository = RatingRepository;
        }
       public async Task add_request(Rating rating )
        {
           await _IRatingRepository.add_request(rating);
        }
    }
}
