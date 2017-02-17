﻿using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetContacts();

        void AddContact(Contact contact);

        void ChangeContactStatus(Contact contact, int statusType, string userProccessedById);

        Contact GetContactById(int id);
    }
}
