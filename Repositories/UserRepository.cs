using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {

        public User GetUserByNameAndPassword(string username, string password)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                PasswordManager passManager = new PasswordManager();
                bool isValidPassoword = passManager.IsPasswordMatch(password, user.Password);
                if (isValidPassoword == false)
                {
                    user = null;
                }
            }
            return user;
        }

        public void RegisterUser(User user, string password)
        {
            PasswordManager passManager = new PasswordManager();
            string hash = passManager.GeneratePasswordHash(password);

            user.Password = hash;

            base.Create(user);
        }

        public User GetUserByName(string username)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            return user;
        }

        public override void Save(User item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, user => user.ID == item.ID);
            }
        }
    }
}
