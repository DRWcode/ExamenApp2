using ExamenApp2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApp2.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection _dbConnection;

        public ProveedorService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<Proveedor>();
        }

        public List<Proveedor> GetAll()
        {
            var res = _dbConnection.Table<Proveedor>().ToList();
            return res;
        }

        public int Insert(Proveedor proveedor)
        {
            return _dbConnection.Insert(proveedor);
        }

        public int Update(Proveedor proveedor)
        {
            return _dbConnection.Update(proveedor);
        }

        public int Delete(Proveedor proveedor)
        {
            return _dbConnection.Delete(proveedor);
        }


    }
}
