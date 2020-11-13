using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mitchell_Vehicle_CRUD.Services
{
    public interface IDataValidation
    {
        bool IsNonEmpty(object o, params string[] propertyNames);
         bool IsInRange(int min, int max,object o, params string[] propertyNames);

    }
}