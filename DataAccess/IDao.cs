﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDao<T>
    {
        T Add(T model);
        bool Delete(T model);
        List<T> GetAll();
        T Update(T model);
        T GetById(int id);
    }
}
