using Dapper;
using MinhasFinancas.Data.DB;
using MinhasFinancas.Models;
using System.Collections.Generic;
using System.Text;


namespace MinhasFinancas.Data
{
    public class LancamentoRepository
    {
        public List<Lancamento> List()
        {
            using (var connection = new DBConnection().GetConnection())
            {
                string sql = @"SELECT ID
                                     ,Description
                                     ,Comments
                                     ,User_Id
                                     ,Category_Id
                                     ,Due_Date
                                     ,Record_Date 
                                     ,Record_Type
                                     ,Value
                               FROM TB_LANCAMENTOS";

                return connection.Query<Lancamento>(sql).AsList();
            }
        }
    }
}