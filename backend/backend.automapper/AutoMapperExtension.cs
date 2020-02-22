﻿using AutoMapper;
using AutoMapper.Configuration;
using backend.util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.automapper
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // 取得所有Profile文件 加入配置。
            var mapperProfiles = ReflectionUtil.GetAllSubClass<Profile>();

            // 整合profile添加 初始化mapper
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            foreach (var profile in mapperProfiles)
            {
                mapperConfigurationExpression.AddProfile(profile);
            }
            var mapper = new Mapper(new MapperConfiguration(mapperConfigurationExpression));
            services.AddSingleton<IMapper>(mapper);

            return services;
        }
    }
}