using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.EF.Models;
using ADO.NET.EF;
using ADO.NET.Controlllers;
namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UnitOfWork unitOfWork= new UnitOfWork(new ApplicationDbContext());
            DataController dataController = new DataController(unitOfWork);
            var result = dataController.GetSuppliersByCountry("France");
            foreach(var i in result)
            {
                Console.WriteLine(i.Name);
            }
            
            


        }
    }
}
