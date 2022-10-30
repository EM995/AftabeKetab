using AftabeKetab.DataModels;

namespace AftabeKetab.API.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AftabeKetabContext context;
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(this.context);
                return _userRepository;
            }
        }

        public RepositoryWrapper(AftabeKetabContext context)
        {
            this.context = context;
        }

        public void Save() => this.context.SaveChanges();
    }
}
