using CryptSharp;
using Dapper;
using MinhasFinancas.Data.DB;
using MinhasFinancas.Models;
using MinhasFinancas.Models.DB;
using MinhasFinancas.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Data
{
    public class UsuarioRepository
    {
        public Usuario GetUsuario(string email, string password)
        {
            using (var connection = new DBConnection().GetConnection())
            {
                string sql = "SELECT ID, EMAIL, PASSWORD, NAME, REGISTRATION_DATE FROM TB_USUARIOS " +
                    "         WHERE LOWER(EMAIL) = LOWER('@EMAIL')" +
                    "           AND PASSWORD = '@PASSWORD'";

                return connection.QuerySingle<Usuario>(sql, new
                {
                    EMAIL = email,
                    PASSWORD = password,
                });
            }
        }

        public LogExecucao Create(Usuario usuario)
        {
            using (var connection = new DBConnection().GetConnection())
            {
                LogExecucao execucao = new LogExecucao();
                string sql = "INSERT INTO TB_USUARIOS(EMAIL, PASSWORD, NAME, REGISTRATION_DATE) " +
                    "                          VALUES(@EMAIL, @PASSWORD, @NAME, SYSDATETIME())";


                if (!EmailExists(usuario.Email))
                {
                    //Criptografa Senha
                    usuario.Password = Crypt(usuario.Password);
                    var dateTime = DateTime.Now;
                    string formatted = dateTime.ToString();
                    usuario.Id = connection.Execute(sql, new
                    {
                        EMAIL = usuario.Email,
                        PASSWORD = usuario.Password,
                        NAME = usuario.Name
                    });

                    execucao.Codigo = usuario.Id;
                    execucao.Mensagem = "Cadastro realizado com sucesso";
                }
                else
                {
                    execucao.Codigo = -1;
                    execucao.Mensagem = "Usuário já possui cadastro";
                }



                return execucao;
            }
        }

        public bool EmailExists(string email)
        {
            using (var connection = new DBConnection().GetConnection())
            {
                string sql = "SELECT COUNT(1) FROM TB_USUARIOS" +
                    "                          WHERE LOWER(EMAIL) = LOWER(@EMAIL)";

                return connection.ExecuteScalar<int>(sql, new { email }) > 0;
            }
        }

        public bool HasLogin(string email, string password)
        {
            using (var connection = new DBConnection().GetConnection())
            {
                string sql = "SELECT Id, Password FROM TB_USUARIOS" +
                    "                          WHERE LOWER(EMAIL) = LOWER(@EMAIL)";
                 
                var retorno = connection.QuerySingle<Usuario>(sql, new { EMAIL = email });

                var result = Match(password, retorno.Password);
                return result;
            }
        }

        #region CRYPT
        private string Crypt(string value)
        {
            return Crypter.Blowfish.Crypt(value);
        }

        private bool Match(string password, string cryptedPassword)
        {
            return Crypter.CheckPassword(password, cryptedPassword);
        }
        #endregion
    }
}