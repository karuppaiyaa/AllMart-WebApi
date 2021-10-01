using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly SettingsRepository settingsRepository = new SettingsRepository();

        public async Task<Settings> Get()
        {
            return await settingsRepository.Get();
        }

    }
}
