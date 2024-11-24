using Microsoft.AspNetCore.SignalR;
using TeamStatus.Services;
using TeamStatusData.Data;
using TeamStatusData.Enums;

namespace TeamStatus.Hubs;

public class UserStatusHub(DataService dataService) : Hub
{
    public async Task UpdateUserStatus(long userId, UserStatus status)
    {
        dataService.UpdateUserStatus(userId, status);
        
        await Clients.All.SendAsync("UpdateUserStatus", userId, status);
    }
}