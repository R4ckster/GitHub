
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class ContaReceberModel : IRepository<ContaReceberModel>
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
//        public string NomeCliente { get; set; }


//        public ContaReceberModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaReceber
//                            join tp in db.TipoContaReceber on p.IdTipoContaReceber equals tp.Id
//                            join cli in db.PessoaJuridica on p.IdPessoaJuridica equals cli.Id into pessoaJuridicaEmpty
//                            from cli in pessoaJuridicaEmpty.DefaultIfEmpty()
//                            where p.Id == pId
//                            select new ContaReceberModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaReceber,
//                                Valor = p.Valor,
//                                DataCadastro = p.DataCadastro,
//                                DataDocumento = p.DataDocumento,
//                                Obs = p.Obs,
//                                Status = p.Status,
//                                Ativo = p.Ativo,
//                                DescricaoTipoConta = tp.Descricao,
//                                NomeCliente = cli.Nome
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<ContaReceberModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaReceber
//                            where p.Ativo == true
//                            select new ContaReceberModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaReceber,
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

//        public IEnumerable<ContaReceberModel> PesquisarPorFiltros(DateTime pDataInicio, DateTime pDataFim, int pIdPessoaJuridica, int pIdTipoConta, string pStatus)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.ContaReceber
//                            join tp in db.TipoContaReceber on p.IdTipoContaReceber equals tp.Id
//                            join cli in db.PessoaJuridica on p.IdPessoaJuridica equals cli.Id into pessoaJuridicaEmpty
//                            from cli in pessoaJuridicaEmpty.DefaultIfEmpty()
//                            where p.Ativo == true
//                            && p.DataDocumento >= pDataInicio
//                            && p.DataDocumento <= pDataFim
//                            && (pIdPessoaJuridica > 0 ? p.IdPessoaJuridica == pIdPessoaJuridica : p.Id == p.Id)
//                            && (pIdTipoConta > 0 ? p.IdTipoContaReceber == pIdTipoConta : p.Id == p.Id)
//                            && (!string.IsNullOrEmpty(pStatus) ? p.Status == pStatus.ToUpper() : p.Id == p.Id)
//                            select new ContaReceberModel
//                            {
//                                Id = p.Id,
//                                IdPessoaJuridica = p.IdPessoaJuridica,
//                                IdTipoConta = p.IdTipoContaReceber,
//                                Valor = p.Valor,
//                                DataCadastro = p.DataCadastro,
//                                DataDocumento = p.DataDocumento,
//                                Obs = p.Obs,
//                                Status = p.Status,
//                                Ativo = p.Ativo,
//                                DescricaoTipoConta = tp.Descricao,
//                                NomeCliente = cli.Nome
//                            }).ToList();

//                return item;
//            }
//        }

//        public bool Excluir(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.ContaReceber where p.Id == pId select p).FirstOrDefault();
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

//        public ContaReceberModel Adicionar(ContaReceberModel item)
//        {
//            var model = new ContaReceber
//            {
//                Id = item.Id,
//                IdPessoaJuridica = item.IdPessoaJuridica,
//                IdTipoContaReceber = item.IdTipoConta,
//                Valor = item.Valor,
//                DataCadastro = DateTime.Now,
//                DataDocumento = item.DataDocumento,
//                Obs = item.Obs,
//                Status = item.Status.ToUpper(),
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.ContaReceber.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public ContaReceberModel Modificar(ContaReceberModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.ContaReceber where p.Id == item.Id select p).FirstOrDefault();
//                if (model != null)
//                {
//                    model.Id = item.Id;
//                    model.IdPessoaJuridica = item.IdPessoaJuridica;
//                    model.IdTipoContaReceber = item.IdTipoConta;
//                    model.Valor = item.Valor;
//                    model.DataDocumento = item.DataDocumento;
//                    model.Obs = item.Obs;
//                    model.Status = item.Status.ToUpper();
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
