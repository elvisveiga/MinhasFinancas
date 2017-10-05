using Dapper;
using MinhasFinancas.Data.DB;
using MinhasFinancas.Models;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Data
{
    public class CategoriaRepository
    {
        public List<Categoria> List()
        {
            using (var connection = new DBConnection().GetConnection())
            {
                string sql = "SELECT ID, DESCRICAO, USER_ID FROM TB_CATEGORIA";
                return connection.Query<Categoria>(sql).AsList();
            }
        }
    }
}