using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WedDesign_Final_RyanWall.Models;

namespace WedDesign_Final_RyanWall.Services
{
    public class CoolRatingService : ICoolRatingService
    {
        
        public int GetCoolRating(Person user)
        {
            int rating = 0;

            if (user.FirstName.StartsWith("R") || user.FirstName.StartsWith("r"))
                rating = 100;

            else if (user.FirstName.StartsWith("Z") || user.FirstName.StartsWith("z"))
                rating = 0;

            else
                rating = 50;

            return rating;
        }
    }
}