using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserProfileModel Profile { get; set; }

        public StatsModel Stats { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}
