using AIRBNB.Models.Entities;

namespace AIRBNB.Repositories
{
    public interface InterfaceUserRole
    {
        List<UserModel> FindAllUsers();

        UserModel AddNewUser(UserModel user);

        UserModel UpdateUser(UserModel user);

        bool DeleteUser(int id);

        UserModel FindById(int id);

        
    }
}
