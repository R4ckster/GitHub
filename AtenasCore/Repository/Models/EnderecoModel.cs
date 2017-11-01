
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class EnderecoModel : IRepository<EnderecoModel>
//    {
//        public int Id { get; set; }
//        public int? IdPessoaJuridica { get; set; }
//        public int? Cep { get; set; }
//        public string Logradouro { get; set; }
//        public string Numero { get; set; }
//        public string Complemento { get; set; }
//        public string Bairro { get; set; }
//        public string Cidade { get; set; }
//        public string Estado { get; set; }
        

//        public IEnumerable<EnderecoModel> PesquisarTodos()
//        {
//            throw new NotImplementedException();
//        }

//        public EnderecoModel PesquisarPorId(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Excluir(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public EnderecoModel Adicionar(EnderecoModel item)
//        {
//            var model = new Endereco
//            {
//                Cep = item.Cep,
//                Logradouro = item.Logradouro,
//                Numero = item.Numero,
//                Complemento = item.Complemento,
//                Bairro = item.Bairro,
//                Cidade = item.Cidade,
//                Estado = item.Estado,
//                IdPessoaJuridica = item.IdPessoaJuridica,
//                DataCadastro = DateTime.Now,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Endereco.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public EnderecoModel Modificar(EnderecoModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Endereco where p.Id == item.Id select p).FirstOrDefault();
//                if (model != null)
//                {
//                    model.Cep = item.Cep;
//                    model.Logradouro = item.Logradouro;
//                    model.Numero = item.Numero;
//                    model.Complemento = item.Complemento;
//                    model.Bairro = item.Bairro;
//                    model.Cidade = item.Cidade;
//                    model.Estado = item.Estado;
//                    db.Entry(model).State = EntityState.Modified;
//                    db.SaveChanges();

//                    return item;
//                }
//                else
//                    return Adicionar(item);

//            }
            
//        }
        
//    }
//}
