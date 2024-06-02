using server.Domain.Models;

namespace server.Domain.Data
{
    public  class UserStore
    {
        public static List<User> UserList = new List<User>{
            new User{Id=1,UserName="Saroj38",FirstName="Saroj",LastName="Guragain",Email="saroj38@gmail.com",Password="password",Status=true},
            new User{Id=2,UserName="Saroj",FirstName="Saroj",LastName="Guragain",Email="saroj38@gmail.com",Password="password",Status=true}
        };
    }
}