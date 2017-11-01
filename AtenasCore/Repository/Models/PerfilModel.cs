
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{

//    public class PerfilModel : IRepository<PerfilModel>
//    {
//        public int Id { get; set; }
//        public string Descricao { get; set; }

//        public PerfilModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Perfil                            
//                            where p.Id == pId
//                            select new PerfilModel
//                            {
//                                Id = p.Id,
//                                Descricao = p.Descricao                                
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<PerfilModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Perfil
//                            where p.Ativo == true
//                            select new PerfilModel
//                            {
//                                Id = p.Id,
//                                Descricao = p.Descricao
//                            }).ToList();
//                return item;
//            }
//        }


//        public bool Excluir(int id)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Perfil where p.Id == Id select p).FirstOrDefault();
//                if (model != null)
//                {
//                    model.Ativo = false;
//                    db.Entry(model).State = EntityState.Modified;
//                    db.SaveChanges();
//                    return true;
//                }
//                else
//                    return false;
//            }
//        }

//        public PerfilModel Adicionar(PerfilModel item)
//        {
//            var model = new Perfil
//            {                
//                Descricao = item.Descricao,                
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Perfil.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public PerfilModel Modificar(PerfilModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Perfil where p.Id == item.Id select p).FirstOrDefault();
//                if (model != null)
//                {
//                    model.Descricao = item.Descricao;
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
