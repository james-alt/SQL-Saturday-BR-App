using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;

namespace SqlSaturday.Infrastructure.Mock.Repositories
{
    public class SavedSessionRepository
        : IRepository<SavedSession, string>
    {
        private List<SavedSession> savedSessions;

        public async Task<SavedSession> GetById(string id)
        {
            await InitializeRepository();

            return savedSessions
                .FirstOrDefault(
                    p => p.Id == id);
        }

        public async Task<IEnumerable<SavedSession>> List()
        {
            await InitializeRepository();

            return savedSessions;
        }

        private async Task InitializeRepository()
        {
            if(savedSessions != null)
            {
                return;
            }

            await Task.Delay(50);

            savedSessions = new List<SavedSession>();
        }
    }
}
