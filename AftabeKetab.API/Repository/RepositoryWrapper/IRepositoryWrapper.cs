namespace AftabeKetab.API.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
