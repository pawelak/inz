﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBL.Interfaces
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        IDbSet<T> GetDbSet<T>() where T : class;
    }
}