using CRNTechnicalAssessment.Domain.Entities;
using CRNTechnicalAssessment.Infrastructure.Data;
using CRNTechnicalAssessment.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRNTechnicalAssessment.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetProductWithItemsAsync(int id)
        {
            return await _context.Products.Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
