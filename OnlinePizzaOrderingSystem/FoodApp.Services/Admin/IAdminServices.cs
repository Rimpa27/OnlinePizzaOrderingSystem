﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IAdminAccessServices
    {
        Task<bool> EditOrderAsync(OrderUpdateModel updateModel);
    }
}
