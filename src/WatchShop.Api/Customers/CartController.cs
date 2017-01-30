﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Customers;

namespace WatchShop.Api.Customers
{
    [SimpleAuthorize]
    public class CartController : ApiController
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IEnumerable<CartItemViewModel> Get()
        {
            return cartRepository
                .GetCart(User.Identity.Name)
                .GetItems()
                .Select(item => new CartItemViewModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
        }

        [HttpPost]
        public void Add([FromBody]CartItemViewModel cartItemViewModel)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            cart.AddItem(cartItemViewModel.ProductId, cartItemViewModel.Quantity);

            cartRepository.Update(cart);
        }
    }
}