
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class TelefoneModel : IRepository<TelefoneModel>
//    {
//        public int Id { get; set; }
//        public int? IdPessoaJuridica { get; set; }
//        public string Numero { get; set; }

//        public IEnumerable<TelefoneModel> PesquisarTodos()
//        {
//            throw new NotImplementedException();
//        }

//        public TelefoneModel PesquisarPorId(int id)
//        {
//            throw new NotImplementedException();
//        }
        

//        public bool Excluir(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public TelefoneModel Adicionar(TelefoneModel item)
//        {
//            var model = new Telefone
//            {
//                IdPessoaJuridica = item.IdPessoaJuridica,
//                Numero = item.Numero,
//                DataCadastro = DateTime.Now,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Telefone.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public TelefoneModel Modificar(TelefoneModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Telefone where p.Id == item.Id select p).FirstOrDefault();
//                if(model != null)
//                { 
//                    model.Numero = item.Numero;                
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
