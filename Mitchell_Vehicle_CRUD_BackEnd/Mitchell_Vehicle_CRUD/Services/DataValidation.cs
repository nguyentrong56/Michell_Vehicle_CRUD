using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Services
{
    public class DataValidation : IDataValidation
    {
        public bool IsNonEmpty(object o, params string[] propertyNames)
        {
            foreach (var property in propertyNames)
            {
                var value = o.GetType().GetProperty(property).GetValue(o,null);
                if (value == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsInRange(int min, int max, object o,  params string[] propertyNames)
        {
            foreach(var property in propertyNames)
            {
                var value = (int)o.GetType().GetProperty(property).GetValue(o, null);
                if (value > max || value < min)
                {
                    return false;
                }
            }
            return true;
        }

      
    }
}