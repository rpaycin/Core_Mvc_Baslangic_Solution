﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Dto
{
    public abstract class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}