using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int ActivationCode { get; set; }

        public bool IsActivated { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ProfileModel Profile { get; set; }
    }
}
