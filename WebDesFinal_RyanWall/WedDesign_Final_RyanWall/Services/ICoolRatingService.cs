using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WedDesign_Final_RyanWall.Models;

namespace WedDesign_Final_RyanWall.Services
{
    public interface ICoolRatingService
    {
        int GetCoolRating(Person user);
    }
}