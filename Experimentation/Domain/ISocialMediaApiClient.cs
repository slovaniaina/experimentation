using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experimentation.Domain.ApiDataModel;
using Experimentation.Domain.Model;

namespace Experimentation.Domain
{
    public interface ISocialMediaApiClient
    {
        string GetTweets();

        Task<UserApiDataModel> GetUser(string clientName);
    }
}
