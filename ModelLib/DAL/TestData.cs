using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using ModelLib.Models;
using ModelLib.Extend;

namespace ModelLib.DAL
{
    public class TestData : ITestData
    {
        public DataTable GetCurrencyTableById()
        {
            var list = GetCurrencyList();

            return list.Where(c => string.Compare(c.CurrencyType, "WON") != 0).Skip(0).Take(3).ToList().ToDataTable();
        }

        public List<CurrencyTest> GetCurrencyList()
        {
            using (ConnContext db = new ConnContext())
            {
                return db.CurrencyTests.ToList();
            }
        }

    }
}
