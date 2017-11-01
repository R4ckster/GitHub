//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class ContaPagarModel : IRepository<ContaPagarModel>
//    {
//        public int Id { get; set; }
//        public int? IdPessoaJuridica { get; set; }
//        public int IdTipoConta { get; set; }
//        public decimal? Valor { get; set; }
//        public DateTime? DataCadastro { get; set; }
//        public DateTime? DataDocumento { get; set; }
//        public string Obs { get; set; }
//        public string Status { get; set; }
//        public bool? Ativo { get; set; }

//        public string DescricaoTipoConta { get; set; }

//        public ContaPagarModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaPagar
//                            join tp in db.TipoContaPagar on p.IdTipoContaPagar equals tp.Id
//                            where p.Id == pId
//                            select new ContaPagarModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaPagar,
//                                Valor = p.Valor,
//                                DataCadastro = p.DataCadastro,
//                                DataDocumento = p.DataDocumento,
//                                Obs = p.Obs,
//                                Status = p.Status,
//                                Ativo = p.Ativo,
//                                DescricaoTipoConta = tp.Descricao
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<ContaPagarModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaPagar
//                            where p.Ativo == true
//                            select new ContaPagarModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaPagar,
//                                Valor = p.Valor,
//                                DataCadastro = p.DataCadastro,
//                                DataDocumento = p.DataDocumento,
//                                Obs = p.Obs,
//                                Status = p.Status,
//                                Ativo = p.Ativo
//                            }).ToList();
//                return item;
//            }
//        }

//        public IEnumerable<ContaPagarModel> PesquisarPorFiltros(DateTime pDataInicio, DateTime pDataFim, int pIdPessoaJuridica, int pIdTipoConta, string pStatus)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaPagar
//                            join tp in db.TipoContaPagar on p.IdTipoContaPagar equals tp.Id
//                            where p.Ativo == true 
//                            && p.DataDocumento >= pDataInicio
//                            && p.DataDocumento <= pDataFim
//                            && (pIdPessoaJuridica > 0 ? p.IdPessoaJuridica == pIdPessoaJuridica : p.Id == p.Id)
//                            && (pIdTipoConta > 0 ? p.IdTipoContaPagar == pIdTipoConta : p.Id == p.Id)
//                            && (!string.IsNullOrEmpty(pStatus) ? p.Status == pStatus : p.Id == p.Id)
//                            select new ContaPagarModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaPagar,
//                                Valor = p.Valor,
//                                DataCadastro = p.DataCadastro,
//                                DataDocumento = p.DataDocumento,
//                                Obs = p.Obs,
//                                Status = p.Status,
//                                Ativo = p.Ativo,
//                                DescricaoTipoConta = tp.Descricao
//                            }).ToList();

//                return item;
//            }
//        }

//        public bool Excluir(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.ContaPagar where p.Id == pId select p).FirstOrDefault();
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

//        public ContaPagarModel Adicionar(ContaPagarModel item)
//        {
//            var model = new ContaPagar
//            {
//                Id = item.Id,
//                IdPessoaJuridica = item.IdPessoaJuridica,
//                IdTipoContaPagar = item.IdTipoConta,
//                Valor = item.Valor,
//                DataCadastro = DateTime.Now,
//                DataDocumento = item.DataDocumento,
//                Obs = item.Obs,
//                Status = item.Status,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.ContaPagar.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public ContaPagarModel Modificar(ContaPagarModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.ContaPagar where p.Id == item.Id select p).FirstOrDefault();
//                if (model != null)
//                {
//                    model.Id = item.Id;
//                    model.IdPessoaJuridica = item.IdPessoaJuridica;
//                    model.IdTipoContaPagar = item.IdTipoConta;
//                    model.Valor = item.Valor;                    
//                    model.DataDocumento = item.DataDocumento;
//                    model.Obs = item.Obs;
//                    model.Status = item.Status;
//                    model.Ativo = true;

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
