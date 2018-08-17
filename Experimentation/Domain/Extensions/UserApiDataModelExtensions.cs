using Experimentation.Domain.ApiDataModel;
using Experimentation.Domain.Model;

namespace Experimentation.Domain.Extensions
{
    public static class UserApiDataModelExtensions
    {
        public static User ToUser(this UserApiDataModel userApiDataModel)
        {
            return new User
            {
                Id = userApiDataModel.Data.Id,
                FirstName = userApiDataModel.Data.FirstName,
                LastName = userApiDataModel.Data.LastName,
                AvatarUrl = userApiDataModel.Data.AvatarUrl
            };
        }
    }
}
