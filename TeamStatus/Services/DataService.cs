
using Microsoft.AspNetCore.SignalR;
using TeamStatusData.Data;
using TeamStatusData.Enums;
using TeamStatusData.Models;

namespace TeamStatus.Services;

public class DataService
{
    private readonly DataContext _dataContext;
    
    public DataService(DataContext dataContext) {
        this._dataContext = dataContext;
    }

    public List<User> GetUsers()
    {
        return _dataContext.Users.OrderBy(u => u.Id).ToList();
    }

    public User GetUserById(long userId)
    {
        return _dataContext.Users.FirstOrDefault(u => u.Id == userId);
    }

    public User UpdateUserStatus(long userId, UserStatus status)
    {
        var user = GetUserById(userId);
        
        user.Status = status;
        
        _dataContext.Users.Update(user);
        _dataContext.SaveChanges();

        return user;
    }
}