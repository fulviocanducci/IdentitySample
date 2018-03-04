﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Domain.Events
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
