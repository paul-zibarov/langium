using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class ProfileModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public StatsModel Stats { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}

