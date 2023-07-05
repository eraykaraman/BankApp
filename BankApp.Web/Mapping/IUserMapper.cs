using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        public List<UserListModel> MapToUserList(List<User> users);
        public UserListModel MapToUserList(User user);
        
    }
}
