using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination>
               IgnoreAllVirtual<TSource, TDestination>(
                   this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                                     p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
}
