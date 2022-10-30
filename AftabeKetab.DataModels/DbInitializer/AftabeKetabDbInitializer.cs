using System.Data.Entity;

namespace AftabeKetab.DataModels
{
    internal class AftabeKetabDbInitializer : DropCreateDatabaseAlways<AftabeKetabContext>
    {
        protected override void Seed(AftabeKetabContext context)
        {
            IList<UserEntity> defaultUsers = new List<UserEntity>();

            defaultUsers.Add(new UserEntity()
            {
                Id = new Guid("D381C6A7-6F50-4719-BD5B-78298F85FB16"),
                FirstName = "Ehsan",
                LastName = "Alizadeh",
            });
            defaultUsers.Add(new UserEntity()
            {
                Id = new Guid("39943C4F-FD52-4B2B-8B4E-30686EA83402"),
                FirstName = "Elham",
                LastName = "Alizadeh",
            });
            defaultUsers.Add(new UserEntity()
            {
                Id = new Guid("6A16084E-BF1A-49A9-B4B0-6B41A527F1E2"),
                FirstName = "Borhan",
                LastName = "Alizadeh",
            });

            context.Users?.AddRange(defaultUsers);

            base.Seed(context);
        }
    }
}
