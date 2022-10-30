using AftabeKetab.API.Repository.Base;
using AftabeKetab.DataModels;

namespace AftabeKetab.API.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AftabeKetabContext context) : base(context)
        {
        }

        public IEnumerable<UserEntity> GetAllUsers() => FindAll().ToList();

        public UserEntity GetUserById(Guid id) => FindByCondition(u => u.Id.Equals(id))
            .FirstOrDefault();

        public void Createuser(UserEntity user) => Create(user);

        public void UpdateUser(UserEntity user) => Update((Guid)user.Id, user);

        public void DeleteUser(UserEntity user) => Delete(user);
    }
}
