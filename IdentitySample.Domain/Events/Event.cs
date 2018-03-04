﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Domain.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
