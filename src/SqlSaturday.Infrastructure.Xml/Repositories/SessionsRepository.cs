using System.Threading.Tasks;
using System.Collections.Generic;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using System.Linq;
using SqlSaturday.Infrastructure.Xml.Services;

namespace SqlSaturday.Infrastructure.Xml.Repositories
{
	public class SessionsRepository
        : IRepository<Session, string>
    {
        public async Task<Session> GetById(string id)
        {
			var sessions = await XmlDataService.Instance.GetSessions();

            return sessions.FirstOrDefault(
                p => p.Id == id);
        }

        public async Task<IEnumerable<Session>> List()
        {
			var sessions = await XmlDataService.Instance.GetSessions();

			return sessions;
        }               
    }
}
