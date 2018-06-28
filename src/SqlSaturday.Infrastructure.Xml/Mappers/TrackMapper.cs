using System.Collections.Generic;
using System.Linq;
using SqlSaturday.Core.Entities;
using SqlSaturday.Infrastructure.Xml.Models;

namespace SqlSaturday.Infrastructure.Xml.Mappers
{
    public static class TrackMapper
    {
        public static IEnumerable<Track> MapTracksFromGuidebook(
            GuidebookDto guidebook)
        {
            if(guidebook.Events != null)
            {
                var tracks = guidebook
                    .Events
                    .Events
                    .Where(t => t != null)
                    .GroupBy(t => t.Track)
                    .Select(eventItem => new Track
                    {
                        Id = eventItem.Key,
                        Title = eventItem.Key
                    })
                    .OrderBy(p => p.Title)
                    .ToList();

                tracks.Insert(0,
                              new Track
                              {
                                  Id = "0",
                                  Title = "All Sessions"
                              });

                return tracks;
            }

            return null;
        }
    }
}
