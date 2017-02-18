﻿using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.Cart
{
    public class CartPresenter : Presenter<ICartView>
    {
        IShoppingCartsService shoppingCartsService;

        public CartPresenter(ICartView view,
            IShoppingCartsService shoppingCartsService) : base(view)
        {
            if(shoppingCartsService == null)
            {
                throw new ArgumentNullException("Shopping carts service cannot be null.");
            }

            this.shoppingCartsService = shoppingCartsService;
            this.View.Initial += OnInitial;
        }

        private void OnInitial(object sender, CartEventArgs e)
        {
            this.View.Model.ShoppingCart = this.shoppingCartsService.GetCart(e.CartId);
        }
    }
}
