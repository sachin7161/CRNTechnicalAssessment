using AutoMapper;
using CRNTechnicalAssessment.Application.DTOs;
using CRNTechnicalAssessment.Domain.Entities;
//using CRNTechnicalAssessment.In.Repositories.Interfaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRNTechnicalAssessment.Application.Interfaces;

namespace CRNTechnicalAssessment.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            product.CreatedBy = "Admin";
            product.CreatedOn = DateTime.UtcNow;

            await _productRepository.AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return false;

            product.ProductName = dto.ProductName;
            product.ModifiedBy = "Admin";
            product.ModifiedOn = DateTime.UtcNow;

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return false;

            _productRepository.Delete(product);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
