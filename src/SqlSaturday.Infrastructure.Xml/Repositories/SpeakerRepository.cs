using SqlSaturday.Core.Interfaces;
using SqlSaturday.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using SqlSaturday.Infrastructure.Xml.Services;

namespace SqlSaturday.Infrastructure.Xml.Repositories
{
    public class SpeakerRepository
        : IRepository<Speaker, string>
    {
        public async Task<Speaker> GetById(string id)
        {
			var speakers = await XmlDataService.Instance.GetSpeakers();

            return speakers
                .FirstOrDefault(
                    prop => prop.Id == id);
        }

        public async Task<IEnumerable<Speaker>> List()
        {
			var speakers = await XmlDataService.Instance.GetSpeakers();

            return speakers;
        }      
    }
}
