using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.PresentationLayer.ViewModels
{
    public class UserUpdateDto
    {
        public string Email { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
