using System;
using System.Collections.Generic;
using ModelLib.Models;
using System.Data;

namespace ModelLib.DAL
{
    public interface ITestData
    {
        List<CurrencyTest> GetCurrencyList();

        DataTable GetCurrencyTableById();



    }
}
