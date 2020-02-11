﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace backend.core.Data
{
    public static class ContextInitializer
    {
        public static void ConfigurationEntity(this ModelBuilder builder, Type dbContextType)
        {
            var libs = DependencyContext.Default.CompileLibraries
                .Where(lib => !lib.Serviceable && lib.Type != "referenceassembly").ToList();
            libs.ForEach(lib =>
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                var entityTypeList = new List<Type>();
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof(EntityAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        if (dbContextType == ((EntityAttribute)attribute).dbContextType)
                        {
                            builder.Entity(type);
                            entityTypeList.Add(type);
                        }
                    }
                }

                builder.ApplyConfigurationsFromAssembly(assembly, type =>
                {
                    var findType = type.GetInterface(typeof(IEntityTypeConfiguration<>).Name)
                        ?.GetGenericArguments()?.FirstOrDefault();
                    if (findType != null && entityTypeList.Contains(findType))
                    {
                        return true;
                    }
                    return false;
                });
            });
        }
    }
}