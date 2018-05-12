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

            return speakers;
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
                ImageUrl = speakerDto.ImageUrl
            };

            return speaker;
        }
    }
}