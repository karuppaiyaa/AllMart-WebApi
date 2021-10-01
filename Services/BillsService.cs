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
    public class BillsService : IBillsService
    {
        private readonly IBillsRepository billsRepository = new BillsRepository();

        public async Task Create(Bills bills)
        {
            await billsRepository.Create(bills);
        }

        public async Task<Bills> GetById(string Id)
        {
            return await billsRepository.GetById(Id);
        }
    }
}
