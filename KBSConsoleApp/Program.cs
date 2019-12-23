using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel;
using ModelLib.DAL;
using ModelLib.Models;
using ChartStructLib.Charts;


namespace KBSConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectTest();
            string result = ChartTest();

            Console.ReadKey();
        }

        static string ChartTest()
        {
            IConnectionDAL connDAL = new ConnectionDAL();
            Conn conn = connDAL.GetConnById(1);
            ChartDAL chartDAL = new ChartDAL();
            //Chart chart = chartDAL.GetChartById(1);
            DataTable chartTable = chartDAL.GetChartTableById(1);
            
            ITestData testData = new TestData();
            DataTable currencyTable = testData.GetCurrencyTableById();
            C3JSLine line = new C3JSLine(currencyTable, chartDAL.CurrentChart.ChartScript);

            string json = line.Generate("CurrencyType", "Currency");

            return json;
        }


        static void ConnectTest()
        {
            ConnectionDAL connDAL = new ConnectionDAL();

            Conn connData = new Conn();
            connData.DBType = "SQLServer";
            connData.ConnStr = "data source=(local);initial catalog=KBS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            connData.AliasName = "SQLTest";

            int result = connDAL.CreateConn(connData);

            Console.WriteLine("{0}", result.ToString());

            Console.WriteLine("----------------");
            Console.WriteLine("-----GETBYID----");
            if (result > 0)
            {
                Conn conn = connDAL.GetConnById(1);
                Console.WriteLine("CId={0}", conn.CId.ToString());
                Console.WriteLine("STR={0}", conn.ConnStr);
                Console.WriteLine("DBType={0}", conn.DBType);
            }
            Console.WriteLine("-------END-GETBYID---------");

            Console.WriteLine("-----GET----");
            if (result > 0)
            {
                var list = connDAL.GetConn();
                foreach (Conn item in list)
                {
                    Console.WriteLine("STR={0}", item.ConnStr);
                }

            }
            Console.WriteLine("-------END-GET---------");
        }

    }
}
