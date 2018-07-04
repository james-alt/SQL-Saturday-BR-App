using System;
using System.Collections.Generic;
using SqlSaturday.Core.Entities;
using SqlSaturday.Infrastructure.Xml.Models;
using System.Linq;
namespace SqlSaturday.Infrastructure.Xml.Mappers
{
	public static class SessionMapper
	{
		public static IEnumerable<Session> MapSessionsFromGuidebook(GuidebookDto guidebook)
		{
			var sessions = new List<Session>();

			if (guidebook.Events != null)
			{
				foreach (var item in guidebook.Events.Events.Where(t => t != null))
				{
					var session = MapSessionFromEventDto(item, guidebook);
					sessions.Add(session);
				}
			}

			return sessions;
		}

		public static Session MapSessionFromEventDto(EventDto eventDto, GuidebookDto guidebook)
		{
			var session = new Session
			{
				Id = eventDto.ImportID,
				Title = eventDto.Title,
				Abstract = eventDto.Description,
				Track = eventDto.Track,
				Room = eventDto.Location.Name,
				SessionStartTime = eventDto.StartTime,
				SessionEndTime = eventDto.EndTime
			};

            var speakers = new List<Speaker>();

            foreach(var speakerDto in eventDto.Speakers.Speakers)
            {
                var speaker = SpeakerMapper
                    .MapSpeakerFromSessionSpeakerDto(
                        speakerDto, guidebook);

                speakers.Add(speaker);
            }

            session.Speakers = speakers;

			return session;
		}
	}
}