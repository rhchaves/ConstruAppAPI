using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Repository
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
