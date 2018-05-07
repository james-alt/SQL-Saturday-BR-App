using System.Threading.Tasks;
using SqlSaturday.Infrastructure.Xml.Models;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;
using SqlSaturday.Core.Entities;
using System.Collections.Generic;
using SqlSaturday.Infrastructure.Xml.Mappers;

namespace SqlSaturday.Infrastructure.Xml.Services
{
    public class XmlDataService
    {
        private static XmlDataService instance;
        private GuidebookDto guidebook;

        private XmlDataService()  { }

        public static XmlDataService Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new XmlDataService();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Session>> GetSessions(bool forceRefresh = false)
        {
            if(ShouldRefresh(forceRefresh))
            {
                guidebook = await GetGuidebookFromXmlService();
            }

            return SessionMapper.MapSessionsFromGuidebook(guidebook);
        }

        private bool ShouldRefresh(bool forceRefresh)
        {
            return guidebook == null || forceRefresh == true;
        }

        private async Task<GuidebookDto> GetGuidebookFromXmlService()
        {
            var streamData = await GetConferenceDataStream();
            var serializer = new XmlSerializer(typeof(GuidebookDto));
            var guidebook = (GuidebookDto)serializer.Deserialize(streamData);

            return guidebook;
        }

        private async Task<Stream> GetConferenceDataStream()
        {
            var conferenceUrl = "https://www.sqlsaturday.com/eventxml.aspx?sat=628";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient
                    .GetAsync(conferenceUrl)
                    .ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                return await response
                    .Content
                    .ReadAsStreamAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
