using AutoMapper;
using CRNTechnicalAssessment.Application.DTOs;
using CRNTechnicalAssessment.Application.Interfaces;
using CRNTechnicalAssessment.Application.Services;
using CRNTechnicalAssessment.Domain.Entities;
using Moq;
using Xunit;

namespace CRNTechnicalAssessment.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _productService = new ProductService(
                _productRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "Laptop"
            };

            var response = new ProductResponseDto
            {
                Id = 1,
                ProductName = "Laptop"
            };

            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(product);

            _mapperMock
                .Setup(x => x.Map<ProductResponseDto>(product))
                .Returns(response);

            
            var result = await _productService.GetByIdAsync(1);

            
            Assert.NotNull(result);
            Assert.Equal(1, result!.Id);
            Assert.Equal("Laptop", result.ProductName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenProductNotFound()
        {
          
            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Product?)null);

           
            var result = await _productService.GetByIdAsync(1);

            
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenProductExists()
        {
           
            var product = new Product
            {
                Id = 1,
                ProductName = "Laptop"
            };

            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(product);

          
            var result = await _productService.DeleteAsync(1);

          
            Assert.True(result);

            _productRepositoryMock.Verify(x => x.Delete(product), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenProductNotFound()
        {
           
            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Product?)null);

           
            var result = await _productService.DeleteAsync(1);

           
            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnProducts()
        {
            
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Laptop"
                }
            };

            var response = new List<ProductResponseDto>
            {
                new ProductResponseDto
                {
                    Id = 1,
                    ProductName = "Laptop"
                }
            };

            _productRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(products);

            _mapperMock
                .Setup(x => x.Map<IEnumerable<ProductResponseDto>>(products))
                .Returns(response);

           
            var result = await _productService.GetAllAsync();

           
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateProduct()
        {
           
            var createDto = new CreateProductDto
            {
                ProductName = "Keyboard"
            };

            var product = new Product
            {
                ProductName = "Keyboard"
            };

            var response = new ProductResponseDto
            {
                ProductName = "Keyboard"
            };

            _mapperMock
                .Setup(x => x.Map<Product>(createDto))
                .Returns(product);

            _mapperMock
                .Setup(x => x.Map<ProductResponseDto>(product))
                .Returns(response);

            
            var result = await _productService.CreateAsync(createDto);

         
            Assert.NotNull(result);
            Assert.Equal("Keyboard", result.ProductName);

            _productRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue_WhenProductExists()
        {
            
            var product = new Product
            {
                Id = 1,
                ProductName = "Old Product"
            };

            var updateDto = new UpdateProductDto
            {
                ProductName = "New Product"
            };

            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(product);

           
            var result = await _productService.UpdateAsync(1, updateDto);

           
            Assert.True(result);

            _productRepositoryMock.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}