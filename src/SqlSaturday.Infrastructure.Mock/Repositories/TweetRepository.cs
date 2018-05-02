using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;

namespace SqlSaturday.Infrastructure.Mock.Repositories
{
    public class TweetRepository
        : IRepository<Tweet, string>
    {
        private List<Tweet> tweets;

        public async Task<Tweet> GetById(string id)
        {
            await InitializeRepository();

            return tweets
                .FirstOrDefault(
                    p => p.Id == id);
        }

        public async Task<IEnumerable<Tweet>> List()
        {
            await InitializeRepository();

            return tweets;
        }

        private async Task InitializeRepository()
        {
            if(tweets != null)
            {
                return;
            }

            await Task.Delay(1000);

            tweets = new List<Tweet>();

            for (var i = 0; i < 20; i++)
            {
                tweets.Add(new Tweet
                {
                    Id = Guid.NewGuid().ToString(),
                    Message = "I like to eat Apples and Bananas",
                    Username = "@Somebody"
                });
            }
        }
    }
}
