using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;

namespace SqlSaturday.Infrastructure.Mock.Repositories
{
    public class SponsorRepository
        : IRepository<Sponsor, string>
    {
        private List<Sponsor> sponsors;

        public async Task<Sponsor> GetById(string id)
        {
            await InitializeRepository();

            return sponsors
                .FirstOrDefault(
                    p => p.Id == id);
        }

        public async Task<IEnumerable<Sponsor>> List()
        {
            await InitializeRepository();

            return sponsors;
        }

        private async Task InitializeRepository()
        {
            if(sponsors != null)
            {
                return;
            }

            await Task.Delay(2000);

            sponsors = new List<Sponsor>();
            for (var i = 0; i < 10; i++)
            {
                sponsors.Add(new Sponsor
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Sponsor {i}",
                    Website = "https://www.google.com",
                    ImageUrl = "https://www.google.com"
                });
            }
        }
    }
}
