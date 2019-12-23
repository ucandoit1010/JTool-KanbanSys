using System;
using System.Collections.Generic;
using System.Linq;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public class DALBase
    {
        internal ConnContext _db;

        public DALBase()
        {
            _db = new ConnContext();

        }

    }
}
