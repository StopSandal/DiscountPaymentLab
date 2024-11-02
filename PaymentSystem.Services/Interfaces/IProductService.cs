using PaymentSystem.DataLayer.Entities;
using PaymentSystem.DataLayer.EntitiesDTO.Product;

public interface IProductService
{
	/// <summary>
	/// Retrieves a Product by its ID.
	/// </summary>
	/// <param name="id">The ID of the Product to retrieve.</param>
	/// <returns>A task that represents the asynchronous operation, containing the Product with the specified ID.</returns>
	Task<Product> GetProductAsync(long id);

	/// <summary>
	/// Retrieves all Products.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation, containing a collection of all Products.</returns>
	Task<IEnumerable<Product>> GetProductsAsync();

	/// <summary>
	/// Creates a new Product.
	/// </summary>
	/// <param name="newProduct">The data transfer object containing the details of the new Product.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	Task CreateProductAsync(AddProductDto newProduct);

	/// <summary>
	/// Updates an existing Product.
	/// </summary>
	/// <param name="id">The ID of the Product to update.</param>
	/// <param name="editProduct">The data transfer object containing the updated details of the Product.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	Task UpdateProductAsync(long id, UpdateProductDto editProduct);

	/// <summary>
	/// Deletes a Product by its ID.
	/// </summary>
	/// <param name="id">The ID of the Product to delete.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	Task DeleteProductAsync(long id);
}