
using TeamStatusData.Data;
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
        return _dataContext.Users.ToList();
    }
}