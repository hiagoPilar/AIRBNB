using AIRBNB.Data;
using AIRBNB.Models.Entities;

namespace AIRBNB.Repositories
{
    public class UserRoleRepository : InterfaceUserRole
    {
        private readonly DataBaseContext _context;

        public UserRoleRepository(DataBaseContext context)
        {
            _context = context;
        }
        
        public UserModel AddNewUser(UserModel user)
        {
            user.CreatedAt = DateTime.Now;

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            UserModel userDB = FindById(id);

            if (userDB == null) throw new Exception("User not find!");

            _context.Users.Remove(userDB);
            _context.SaveChanges();
            return true;
        }

        public List<UserModel> FindAllUsers()
        {
            return _context.Users.ToList();
        }

        public UserModel FindById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel UpdateUser(UserModel user)
        {
            UserModel userDB = FindById(user.Id);

            if (userDB == null) throw new Exception("User not find");

            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            userDB.Email = user.Email;
            userDB.Bio = user.Bio;
            userDB.ProfilePictureUrl = user.ProfilePictureUrl;

            _context.Users.Update(userDB);
            _context.SaveChanges();
            return userDB;
        }
    }
}
