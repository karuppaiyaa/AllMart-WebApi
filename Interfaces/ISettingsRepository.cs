using AllMart_WebApi.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Interfaces
{
    public interface ISettingsRepository
    {
        public Task<Settings> Get();
    }
}
