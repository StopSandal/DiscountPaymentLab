using AutoMapper;
using Microsoft.Extensions.Logging;
using PaymentSystem.DataLayer.Entities;
using PaymentSystem.DataLayer.EntitiesDTO.Product;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.Services.Services
{
	/// <summary>
	/// Service for handling Product-related operations such as creating, updating, retrieving, and deleting Products.
	/// Implements <see cref="IProductService"/>.
	/// </summary>
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ILogger<ProductService> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProductService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work for interacting with repositories.</param>
		/// <param name="mapper">The mapper for entity-DTO transformations.</param>
		/// <param name="logger">The logger for logging information.</param>
		public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_logger = logger;
		}

		/// <inheritdoc />
		/// <exception cref="Exception">Thrown when an error occurs while fetching the Product.</exception>
		public async Task<Product> GetProductAsync(long id)
		{
			try
			{
				_logger.LogInformation("Fetching Product with ID: {ProductId}", id);
				var Product = await _unitOfWork.ProductRepository.GetByIDAsync(id);
				if (Product == null)
				{
					_logger.LogWarning("Product with ID: {ProductId} not found", id);
					throw new ArgumentNullException("Product doesn't exists");
				}
				return Product;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching Product with ID: {ProductId}", id);
				throw;
			}
		}

		/// <inheritdoc />
		/// <exception cref="Exception">Thrown when an error occurs while fetching all Products.</exception>
		public async Task<IEnumerable<Product>> GetProductsAsync()
		{
			try
			{
				_logger.LogInformation("Fetching all Products");
				return await _unitOfWork.ProductRepository.GetAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching all Products");
				throw;
			}
		}

		/// <inheritdoc />
		/// <exception cref="Exception">Thrown when an error occurs while creating the Product.</exception>
		public async Task CreateProductAsync(AddProductDto newProduct)
		{
			try
			{
				_logger.LogInformation("Creating a new Product");
				await _unitOfWork.ProductRepository.InsertAsync(_mapper.Map<Product>(newProduct));
				await _unitOfWork.SaveAsync();
				_logger.LogInformation("Product created successfully");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating new Product");
				throw;
			}
		}

		/// <inheritdoc />
		/// <exception cref="Exception">Thrown when an error occurs while deleting the Product.</exception>
		public async Task DeleteProductAsync(long id)
		{
			try
			{
				_logger.LogInformation("Deleting Product with ID: {ProductId}", id);
				await _unitOfWork.ProductRepository.DeleteAsync(id);
				await _unitOfWork.SaveAsync();
				_logger.LogInformation("Product deleted successfully with ID: {ProductId}", id);
			}
			catch (ArgumentNullException ex)
			{
				_logger.LogError(ex, "Error deleting Product with ID: {ProductId}", id);
				throw new Exception("Product doesn't exists");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting Product with ID: {ProductId}", id);
				throw;
			}
		}

		/// <inheritdoc />
		/// <exception cref="InvalidDataException">Thrown when the Product to update does not exist.</exception>
		/// <exception cref="Exception">Thrown when an error occurs while updating the Product.</exception>
		public async Task UpdateProductAsync(long id, UpdateProductDto editProduct)
		{
			try
			{
				_logger.LogInformation("Updating Product with ID: {ProductId}", id);
				var item = await _unitOfWork.ProductRepository.GetByIDAsync(id);
				if (item == null)
				{
					_logger.LogWarning("No Product found to update with ID: {ProductId}", id);
					throw new InvalidDataException("No Product to update");
				}
				_mapper.Map(editProduct, item);
				_unitOfWork.ProductRepository.Update(item);
				await _unitOfWork.SaveAsync();
				_logger.LogInformation("Product updated successfully with ID: {ProductId}", id);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating Product with ID: {ProductId}", id);
				throw;
			}
		}
	}
}
