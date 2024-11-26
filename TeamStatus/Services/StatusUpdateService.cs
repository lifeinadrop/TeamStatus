using Microsoft.AspNetCore.SignalR;
using TeamStatus.Hubs;
using TeamStatusData.Enums;
using Enum = System.Enum;

namespace TeamStatus.Services;

public class StatusUpdateService
{
    private readonly DataService _dataService;
    private readonly IHubContext<UserStatusHub> _hubContext;

    public StatusUpdateService(DataService dataService, IHubContext<UserStatusHub> hubContext)
    {
        _dataService = dataService;
        _hubContext = hubContext;
    }

    public async Task UpdateUserStatus(long userId, UserStatus status)
    {
        _dataService.UpdateUserStatus(userId, status); 
        await _hubContext.Clients.All.SendAsync("UpdateUserStatus", userId, Enum.GetName(typeof(UserStatus), status));
    }
}