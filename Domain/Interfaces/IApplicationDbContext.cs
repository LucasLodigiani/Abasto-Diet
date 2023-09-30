﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ProductEntity> Products { get; }

        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
