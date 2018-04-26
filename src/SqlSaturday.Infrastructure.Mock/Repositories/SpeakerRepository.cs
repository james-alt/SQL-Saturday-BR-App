using SqlSaturday.Core.Interfaces;
using SqlSaturday.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SqlSaturday.Infrastructure.Mock.Repositories
{
    public class SpeakerRepository
        : IRepository<Speaker, string>
    {
        private List<Speaker> speakers;

        public async Task<Speaker> GetById(string id)
        {
            await InitializeRepository();

            return speakers
                .FirstOrDefault(
                    prop => prop.Id == id);
        }

        public async Task<IEnumerable<Speaker>> List()
        {
            await InitializeRepository();

            return speakers;
        }

        private async Task InitializeRepository()
        {
            if(speakers != null)
            {
                return;
            }

            await Task.Delay(2000);

            speakers = new List<Speaker>
            {
                new Speaker 
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "James Alt",
                    Description = "Beautiful Bald Bastard",
                    Twitter = "jimmyalt",
                },
                new Speaker
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Isral Duke",
                    Description = "Something Punny"
                },
                new Speaker
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "William Assaf",
                    Description = "A Member of the League of Beautiful Bald Bastards"
                }
            };
        }
    }
}
