﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Users.Profile
{
    public interface IUserView : IView<UserViewModel>
    {
        event EventHandler<UserByIdEventArgs> Initial;
    }
}
