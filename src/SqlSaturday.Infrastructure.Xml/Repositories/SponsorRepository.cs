using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using SqlSaturday.Infrastructure.Xml.Services;

namespace SqlSaturday.Infrastructure.Xml.Repositories
{
    public class SponsorRepository
        : IRepository<Sponsor, string>
    {
        public async Task<Sponsor> GetById(string id)
        {
			var sponsors = await XmlDataService.Instance.GetSponsors();

            return sponsors
                .FirstOrDefault(
                    p => p.Id == id);
        }

        public async Task<IEnumerable<Sponsor>> List()
        {
			var sponsors = await XmlDataService.Instance.GetSponsors();

            return sponsors;
        }        
    }
}
