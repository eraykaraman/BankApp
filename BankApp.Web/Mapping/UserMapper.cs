using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class UserMapper: IUserMapper
    {
        public List<UserListModel> MapToUserList(List<User> users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,
            }).ToList();
        }

        public UserListModel MapToUserList(User user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname
            };
        }

       
    }
}
