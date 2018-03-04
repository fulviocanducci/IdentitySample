﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using IdentitySample.Domain.Events;

namespace IdentitySample.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
