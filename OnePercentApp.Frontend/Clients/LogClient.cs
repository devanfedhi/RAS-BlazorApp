using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using OnePercentApp.Frontend.Data;
using OnePercentApp.Frontend.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;

namespace OnePercentApp.Frontend.Clients
{
    public class LogClient
    {
        private readonly OnePercentAppContext _onePercentAppContext;
        private Task<AuthenticationState> _authenticationStateTask;

        public LogClient(OnePercentAppContext onePercentAppContext)
        {
            _onePercentAppContext = onePercentAppContext;
        }

        public void SetAuthenticationStateTask(Task<AuthenticationState> authenticationStateTask)
        {
            _authenticationStateTask = authenticationStateTask;
        }

        public async Task AddLogAsync(LogViewModel log)
        {
            var authenticationState = await _authenticationStateTask;
            var user = authenticationState.User;

            var userId = Convert.ToInt32(user.FindFirst("UserId").Value);

            var newLog = new Log
            {
                LogDate = log.Date,
                LogTitle = log.Title,
                LogDescription = log.Description,
                UserId = userId
            };

            await _onePercentAppContext.Logs.AddAsync(newLog);
            await _onePercentAppContext.SaveChangesAsync();
        }
    }
}