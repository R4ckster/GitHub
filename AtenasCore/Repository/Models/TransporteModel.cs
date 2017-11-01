
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class TransporteModel : IRepository<TransporteModel>
//    {
//        public int Id { get; set; }
//        public string Descricao { get; set; }

//        public TransporteModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Transporte
//                            where p.Id == pId
//                            select new TransporteModel
//                            {
//                                Id = p.Id,
//                                Descricao = p.Descricao
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<TransporteModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Transporte
//                            where p.Ativo == true
//                            select new TransporteModel
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
//                var model = (from p in db.Transporte where p.Id == Id select p).FirstOrDefault();
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

//        public TransporteModel Adicionar(TransporteModel item)
//        {
//            var model = new Transporte
//            {
//                Descricao = item.Descricao,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Transporte.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public TransporteModel Modificar(TransporteModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Transporte where p.Id == item.Id select p).FirstOrDefault();
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
