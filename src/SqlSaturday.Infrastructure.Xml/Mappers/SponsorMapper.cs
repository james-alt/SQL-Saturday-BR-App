using SqlSaturday.Core.Entities;
using SqlSaturday.Infrastructure.Xml.Models;
using System.Collections.Generic;
using System.Linq;

namespace SqlSaturday.Infrastructure.Xml.Mappers
{
    public static class SponsorMapper
    {
		public static IEnumerable<Sponsor> MapSponsorsFromGuidebook(GuidebookDto guidebook)
		{
			var sponsors = new List<Sponsor>();

            if(guidebook.Sponsors != null)
			{
				foreach(var item in guidebook.Sponsors.Sponsors.Where(t => t != null))
				{
					var sponsor = MapSponsorFromSponsorDto(item);
					sponsors.Add(sponsor);
				}
			}

			return sponsors;
		}

        public static Sponsor MapSponsorFromSponsorDto(SponsorDto sponsorDto)
        {
            var sponsor = new Sponsor
            {
                Id = sponsorDto.ImportId,
                Name = sponsorDto.Name,
                SponsorLevel = MapSponsorLevelFromLabel(sponsorDto.Label),
                Website = sponsorDto.Url,
                ImageUrl = sponsorDto.ImageUrl
            };

            return sponsor;
        }

        private static SponsorLevel MapSponsorLevelFromLabel(string label)
        {
            var level = new SponsorLevel();
            switch (label)
            {
                case "Platinum":
                    level.Id = 0;
                    level.Label = "Platinum";
                    break;
                case "Gold Sponsor":
                    level.Id = 1;
                    level.Label = "Gold";
                    break;
                case "Silver Sponsor":
                    level.Id = 2;
                    level.Label = "Silver";
                    break;
                case "Bronze Sponsor":
                    level.Id = 3;
                    level.Label = "Bronze";
                    break;
                case "Facility Sponsorship":
                    level.Id = 4;
                    level.Label = "Facility";
                    break;
                default:
                    level.Id = 5;
                    level.Label = label;
                    break;
            }

            return level;
        }
    }
}
