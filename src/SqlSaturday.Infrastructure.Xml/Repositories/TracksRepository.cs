using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using SqlSaturday.Infrastructure.Xml.Services;

namespace SqlSaturday.Infrastructure.Xml.Repositories
{
    public class TracksRepository
        : IRepository<Track, string>
    {

        public async Task<Track> GetById(string id)
        {
            var tracks = await XmlDataService.Instance.GetTracks();

            return tracks.FirstOrDefault(
                p => p.Id == id);
        }

        public async Task<IEnumerable<Track>> List()
        {
            var tracks = await XmlDataService.Instance.GetTracks();

            return tracks;
        }
    }
}
