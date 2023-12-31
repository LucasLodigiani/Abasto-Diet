﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        IPAddress? UserClientIpAddress { get; }
        
        Boolean isAdmin { get; }
        Boolean isUser { get; }
        
    }
}
