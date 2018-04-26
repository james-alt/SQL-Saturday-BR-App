using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using System.Linq;

namespace SqlSaturday.Infrastructure.Mock.Repositories
{
    public class SessionsRepository
        : IRepository<Session, string>
    {
        private List<Session> sessions;

        public async Task<Session> GetById(string id)
        {
            await InitializeRepository();

            return sessions.FirstOrDefault(
                p => p.Id == id);
        }

        public async Task<IEnumerable<Session>> List()
        {
            await InitializeRepository();

            return sessions;
        }

        private async Task InitializeRepository()
        {
            if(sessions != null)
            {
                return;
            }

            await Task.Delay(1000);

            sessions = new List<Session>();
            var tempDate = DateTime.Parse("08/11/2018 08:00:00");

            for (var i = 0; i < 40; i++)
            {
                if(i%6 == 0)
                {
                    tempDate = tempDate.AddHours(1);
                }

                sessions.Add(new Session
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = $"Session {i}",
                    SessionTime = tempDate
                });
            }
        }
    }
}
