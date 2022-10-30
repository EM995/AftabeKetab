using AftabeKetab.DataModels;

namespace AftabeKetab.API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetAllUsers();
        UserEntity GetUserById(Guid id);
        void CreateUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}
