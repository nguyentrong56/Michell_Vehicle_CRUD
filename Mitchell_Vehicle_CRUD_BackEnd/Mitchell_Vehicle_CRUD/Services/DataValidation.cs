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
        /// <summary>
        /// Function checks for non-empty property
        /// </summary>
        /// <param name="o"> Generic Object </param>
        /// <param name="propertyNames"> List of properties need to checked </param>
        /// <returns></returns>
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

        /// <summary>
        /// Function check if property value is in range
        /// </summary>
        /// <param name="min"> lower bound</param>
        /// <param name="max"> upper bound </param>
        /// <param name="o"> generic object </param>
        /// <param name="propertyNames"> List of properties needed to be checked </param>
        /// <returns></returns>
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