
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class StatusModel : IRepository<StatusModel>
//    {
//        public int Id { get; set; }
//        public string Descricao { get; set; }

//        public StatusModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Status
//                            where p.Id == pId
//                            select new StatusModel
//                            {
//                                Id = p.Id,
//                                Descricao = p.Descricao
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<StatusModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Status
//                            where p.Ativo == true
//                            select new StatusModel
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
//                var model = (from p in db.Status where p.Id == Id select p).FirstOrDefault();
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

//        public StatusModel Adicionar(StatusModel item)
//        {
//            var model = new Status
//            {
//                Descricao = item.Descricao,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Status.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public StatusModel Modificar(StatusModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Status where p.Id == item.Id select p).FirstOrDefault();
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
