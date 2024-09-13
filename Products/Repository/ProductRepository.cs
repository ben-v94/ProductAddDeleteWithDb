using Products.Models;
using Products;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly MyDbContext _context;

    public ProductRepository(MyDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductViewModel> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddAsync(ProductViewModel product)
    {
        _context.Products.Add(product);
    
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}