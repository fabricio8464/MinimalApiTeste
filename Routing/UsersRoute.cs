using Microsoft.EntityFrameworkCore;
using MinimalAPiTeste.Entities;

namespace MinimalAPiTeste.Routing
{
    public class UsersRoute
    {

       public async static Task<List<Users_Log>> GetUserLog(AppDbContext db)
        {
            return await db.Users_Log.ToListAsync();
        }

        public async static Task<Users_Log> CreateUserLog(AppDbContext db, Users_Log user)
        {
            db.Users_Log.Add(user);
            db.SaveChanges();
            return user;
        }

        public async static Task<Users_Log> EditUserLog(AppDbContext db, int id, Users_Log userUpdated)
        {
            var userFinded = db.Users_Log.Find(id);
            userFinded.Name = userUpdated.Name;
            userFinded.Email = userUpdated.Email;
            userFinded.Ultimo_Login = userUpdated.Ultimo_Login == null ? DateTime.Parse("0000-00-00") : userUpdated.Ultimo_Login; 
            return userFinded;
        }

        public async static Task<Users_Log> DeleteUserLog (AppDbContext db, int userID)
        {
            var user = db.Users_Log.Find(userID);
            db.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
