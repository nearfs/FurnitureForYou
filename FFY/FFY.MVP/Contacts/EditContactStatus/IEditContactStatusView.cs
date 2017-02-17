﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Contacts.EditContactStatus
{
    public interface IEditContactStatusView : IView<EditContactStatusViewModel>
    {
        event EventHandler<GetContactByIdEventArgs> Initial;

        event EventHandler<EditContactStatusEventArgs> EdittingContact;
    }
}
