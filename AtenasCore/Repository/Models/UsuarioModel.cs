using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Repository.Models
{
    public class UsuarioModel : IRepository<UsuarioModel>
    {        

        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string Login { get; set; }        
        public string Senha { get; set; }
        public int? PerfilUsuario { get; set; }
        public bool? Ativo { get; set; }

        public UsuarioModel PesquisarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Adicionar(UsuarioModel item)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Modificar(UsuarioModel item)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Acessar(string login, string senha)
        {
            var query = @" Select Id, Nome, Login, Senha, PerfilUsuario, Ativo from Usuario                           
                           where Login = @Login AND Senha = @Senha; ";

            using (var db = new System.Data.SqlClient.SqlConnection(@"Server=(localhost)\\sqlexpress;Database=AtenasData2;user id=sa;password=Asdqwe123;Trusted_Connection=True;"))
            {
                var usuario = db.Query<UsuarioModel>(query, new { Login = login, Senha = senha });
                return usuario.FirstOrDefault();
            }

            
        }

        public IEnumerable<UsuarioModel> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
