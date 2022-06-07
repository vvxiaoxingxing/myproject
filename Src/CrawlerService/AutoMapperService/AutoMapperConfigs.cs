using AutoMapper;
using CrawlerModels;
using ICrawlerService.Dtos;
using ICrawlerService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerService.AutoMapperService
{
    /// <summary>
    /// automapper 
    /// </summary>
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<Array3Entity, Array3>();
            CreateMap<Array3, Array3RespDtos>();
        }
    }
}
