using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<WordModel> Words { get; set; }

        public int ProfileId { get; set; }

        public ProfileModel Profile { get; set; }
    }
}
