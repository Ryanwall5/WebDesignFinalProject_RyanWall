
using WedDesign_Final_RyanWall.Models;

namespace WedDesign_Final_RyanWall.Services
{
    public class UserService : IUserService
    {
        private readonly ICoolRatingService _coolratingservice;
        public static int Coolthreshold = 70;

        public UserService(ICoolRatingService coolratingservice)
        {
            _coolratingservice = coolratingservice;
        }

        public bool UserIsCool(Person user)
        {

            var CoolRating = _coolratingservice.GetCoolRating(user);
            return user.DoYouPlayVG && (user.NickName.StartsWith("C") || user.NickName.StartsWith("G")) && CoolRating > Coolthreshold;

        }
    }


}