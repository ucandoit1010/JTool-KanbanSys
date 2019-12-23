using System;
using System.Collections.Generic;
using System.Linq;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public interface IConnectionDAL
    {
        int CreateConn(Conn data);

        List<Conn> GetConn();

        Conn GetConnById(int id);

        Conn UpdateConnById(Conn conn);

        int RemoveConnById(int id);

    }
}
