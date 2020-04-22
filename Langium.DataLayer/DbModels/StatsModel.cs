﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class StatsModel
    {
        public int Id { get; set; }

        public int TotalAnswers { get; set; }

        public int RightAnswers { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }
    }
}
