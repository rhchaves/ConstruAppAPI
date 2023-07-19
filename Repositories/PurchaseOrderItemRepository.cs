using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Repository
{
    public class PurchaseOrderItemRepository : Repository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
