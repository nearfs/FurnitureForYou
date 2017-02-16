﻿using FFY.MVP.Products.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Furniture
{
    [PresenterBinding(typeof(GetProductByIdPresenter))]
    public partial class FurnitureDetailed : MvpPage<GetProductByIdViewModel>, IGetProductByIdView
    {
        public event EventHandler<GetProductByIdEventArgs> GettingProductById;

        protected void Page_Load(object sender, EventArgs e)
        {
            var productIdParameter = this.Page.RouteData.Values["productId"].ToString();

            int productId;

            if(!(int.TryParse(productIdParameter, out productId)))
            {
                //TODO: 404
                this.Response.Redirect("~/");
            }

            this.GettingProductById?.Invoke(this, new GetProductByIdEventArgs(productId));

            if(this.Model.Product == null)
            {
                //TODO: 404
                this.Response.Redirect("~/");
            }
        }
    }
}