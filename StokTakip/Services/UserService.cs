using StokTakip.Entities.Concrete;
using StokTakip.Entities.Context;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(StokContext stokContext) : base(stokContext)
        {

        }
    }
}
