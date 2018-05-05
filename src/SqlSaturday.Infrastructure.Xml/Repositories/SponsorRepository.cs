using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;

namespace SqlSaturday.Infrastructure.Xml.Repositories
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
                    ImageUrl = "https://www.google.com",
                    SponsorLevel = GenerateSponsorLevel(i)
                });
            }
        }

        private SponsorLevel GenerateSponsorLevel(int seed)
        {
            var number = seed % 5;

            var sponsorLevel = new SponsorLevel
            {
                Id = number
            };

            switch(number)
            {
                case 0:
                    sponsorLevel.Label = "Platinum";
                    break;
                case 1:
                    sponsorLevel.Label = "Gold";
                    break;
                case 2:
                    sponsorLevel.Label = "Silver";
                    break;
                case 3:
                    sponsorLevel.Label = "Bronze";
                    break;
                case 4:
                    sponsorLevel.Label = "Education";
                    break;
            }

            return sponsorLevel;
        }
    }
}
