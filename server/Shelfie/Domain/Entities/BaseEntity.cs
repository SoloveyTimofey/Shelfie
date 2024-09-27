﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string CreatorId { get; set; } = string.Empty;
    }
}
