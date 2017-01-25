﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Domain.Catalog;

namespace WatchShop.Api.Catalog
{
    public class CatalogController : ApiController
    {
        private readonly IProductRepository productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public CatalogRepresentation Get()
        {
            IEnumerable<ProductRepresentation> products = productRepository
                .GetProdutcs()
                .Select(product => new ProductRepresentation
            {
                Id = product.Id,
                Name = product.Name
            }).ToList();

            return new CatalogRepresentation(products);
        }

        public ProductRepresentation GetProduct(int id)
        {
            return productRepository
                .GetProdutcs()
                .Where(product => product.Id == id)
                .Select(product => new ProductRepresentation
                {
                    Id = product.Id,
                    Name = product.Name
                }).Single();
        }
    }
}