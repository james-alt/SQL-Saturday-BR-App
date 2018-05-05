using System;
using System.Threading.Tasks;
using SqlSaturday.Infrastructure.Xml.Models;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;

namespace SqlSaturday.Infrastructure.Xml.Services
{
    public class XmlDataService
    {
        private static XmlDataService instance;

        private XmlDataService() { }

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

        public async Task<Conference> GetConference()
        {
            var streamData = await GetConferenceDataStream();
            var serializer = new XmlSerializer(typeof(GuidebookDto));
            var guidebook = (GuidebookDto) serializer.Deserialize(streamData);

            return new Conference();
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
