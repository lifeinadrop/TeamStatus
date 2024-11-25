using Microsoft.AspNetCore.SignalR;
using TeamStatus.Hubs;
using TeamStatusData.Enums;

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

    public async Task UpdateUserStatusAsync(long userId, UserStatus status)
    {
        _dataService.UpdateUserStatus(userId, status); 
        await _hubContext.Clients.All.SendAsync("UpdateUserStatus", userId, status);
    }
}