using Products.Models;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetByIdAsync(int id);
    Task AddAsync(ProductViewModel product);
    Task DeleteAsync(int id);
}