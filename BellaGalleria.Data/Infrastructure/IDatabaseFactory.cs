﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaGalleria.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        BellaGalleriaEntities Get();
    }
}