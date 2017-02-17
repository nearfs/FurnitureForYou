﻿using FFY.Models;
using FFY.MVP.Users.SendContact;
using FFY.Order;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web
{
    [PresenterBinding(typeof(SendContactPresenter))]
    public partial class Contact : MvpPage<SendContactViewModel>, ISendContactView
    {
        public event EventHandler<SendContactEventArgs> SendingContact;

        protected void Page_Load(object sender, EventArgs e)
        {
            var cart = this.Session[string.Format("cart-{0}", this.User.Identity.GetUserName())] as SessionShoppingCart;
            this.TestLbl.Text = cart.ShoppingCart.Total().ToString();
        }

        protected void SendContactClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var contact = new Models.Contact
                {
                    Email = this.Email.Text,
                    Title = this.EmailTitle.Text,
                    EmailContent = this.EmailContent.Text,
                    SendOn = DateTime.Now,
                    ContactStatusType = ContactStatusType.NotProcessed
                };

                this.SendingContact?.Invoke(this, new SendContactEventArgs(contact));
            }
        }
    }
}