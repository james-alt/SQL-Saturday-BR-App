using System.Collections.Generic;
using SqlSaturday.Core.Entities;
using SqlSaturday.Infrastructure.Xml.Models;
using System.Linq;
namespace SqlSaturday.Infrastructure.Xml.Mappers
{
    public static class SpeakerMapper
    {
        public static IEnumerable<Speaker> MapSpeakersFromGuidebook(GuidebookDto guidebook)
        {
            var speakers = new List<Speaker>();

            if (guidebook.Speakers != null)
            {
                foreach (var item in guidebook.Speakers.Speakers.Where(t => t != null))
                {
                    var speaker = MapSpeakerFromSpeakerDto(item);
                    speakers.Add(speaker);
                }
            }

            foreach(var speaker in speakers)
            {
                speaker.SpeakerIds = speakers
                    .Where(p => p.Name == speaker.Name)
                    .Select(p => p.Id)
                    .ToList();
            }

            return speakers
                .GroupBy(p => p.Name)
                .Select(s => s.First())
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();
        }

        public static Speaker MapSpeakerFromSpeakerDto(SpeakerDto speakerDto)
        {
            var speaker = new Speaker
            {
                Id = speakerDto.ImportId,
                Name = speakerDto.Name,
                Description = speakerDto.Description,
                Twitter = speakerDto.Twitter,
                LinkedIn = speakerDto.LinkedIn,
                Website = speakerDto.ContactUrl,
                ImageUrl = speakerDto.ImageUrl,
                SpeakerIds = new List<string>()
            };

            return speaker;
        }

        public static Speaker MapSpeakerFromSessionSpeakerDto(SessionSpeakerDto sessionSpeakerDto, GuidebookDto guidebook)
        {
            var speakerDto = guidebook
                .Speakers
                .Speakers
                .FirstOrDefault(p => p.ImportId == sessionSpeakerDto.Id);

            if (speakerDto == null)
                return null;

            return MapSpeakerFromSpeakerDto(speakerDto);
        }
    }
}