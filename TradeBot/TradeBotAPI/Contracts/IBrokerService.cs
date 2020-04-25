using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeBotAPI.Models;

namespace TradeBotAPI.Services
{
    public interface IBrokerService
    {
        public AccessTokenResponse BearerToken { get; set; }

        public Task<Portfolio> GetPortfolioAsync();

        //Task<List<Todo>> GetAllAsync();
        //Task<Todo> GetTodoAsync(int id);
        //Task<Todo> CreateTodoAsync(Todo task);
        //Task<Todo> UpdateTodoAsync(Todo task);
        //Task DeleteTodoAsync(int id);

    }
}