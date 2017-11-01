//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Repository.Models
//{
//    public class PessoaJuridicaModel : IRepository<PessoaJuridicaModel>
//    {
//        public int Id { get; set; }
//        public int? IdPerfil { get; set; }
//        public string Nome { get; set; }
//        public string CpfCnpj { get; set; }
//        public string Logo { get; set; }
//        public decimal? Mensalidade { get; set; }
//        public DateTime? DataCadastro { get; set; }
//        public bool? Ativo { get; set; }        
//        public PerfilModel PerfilModel { get; set; }
//        public List<TelefoneModel> TelefoneModel { get; set; }
//        public List<EnderecoModel> EnderecoModel { get; set; }


//        public PessoaJuridicaModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.PessoaJuridica
//                            .Include(t => t.Telefone)
//                            .Include(e => e.Endereco)
//                            .Include(pf => pf.Perfil)
//                            where p.Id == pId
//                            select new PessoaJuridicaModel
//                            {
//                                Id = p.Id,
//                                IdPerfil = p.IdPerfil,
//                                Nome = p.Nome,
//                                CpfCnpj = p.CpfCnpj,
//                                Logo = p.Logo,
//                                Mensalidade = p.Mensalidade,
//                                DataCadastro = p.DataCadastro,
//                                Ativo = p.Ativo,
//                                PerfilModel = new PerfilModel { Id = p.Perfil.Id, Descricao = p.Perfil.Descricao },
//                                TelefoneModel = (from  tt in p.Telefone where tt.Ativo == true select new TelefoneModel {
//                                    Id = tt.Id, IdPessoaJuridica = tt.IdPessoaJuridica, Numero = tt.Numero }).ToList(),
//                                EnderecoModel = (from end in p.Endereco where end.Ativo == true select new EnderecoModel {
//                                    Id = end.Id, IdPessoaJuridica = end.IdPessoaJuridica, Cep = end.Cep, Logradouro = end.Logradouro,
//                                    Numero = end.Numero, Complemento = end.Complemento, Bairro = end.Bairro, Cidade = end.Cidade,
//                                    Estado = end.Estado}).ToList()
//                            }).FirstOrDefault();
//                return item;
//            }
//        }
        
//        public IEnumerable<PessoaJuridicaModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.PessoaJuridica
//                            .Include(t => t.Telefone)
//                            .Include(e => e.Endereco)
//                            .Include(pf => pf.Perfil)
//                            where p.Ativo == true
//                            select new PessoaJuridicaModel
//                            {
//                                Id = p.Id,
//                                IdPerfil = p.IdPerfil,
//                                Nome = p.Nome,
//                                CpfCnpj = p.CpfCnpj,
//                                Logo = p.Logo,
//                                Mensalidade = p.Mensalidade,
//                                DataCadastro = p.DataCadastro,
//                                Ativo = p.Ativo,
//                                PerfilModel = new PerfilModel { Id = p.Perfil.Id, Descricao = p.Perfil.Descricao },
//                                TelefoneModel = (from tt in p.Telefone
//                                                 where tt.Ativo == true
//                                                 select new TelefoneModel
//                                                 {
//                                                     Id = tt.Id,
//                                                     IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                     Numero = tt.Numero,                                                     
//                                                 }).ToList(),
//                                EnderecoModel = (from end in p.Endereco
//                                                 where end.Ativo == true
//                                                 select new EnderecoModel
//                                                 {
//                                                     Id = end.Id,
//                                                     IdPessoaJuridica = end.IdPessoaJuridica,
//                                                     Cep = end.Cep,
//                                                     Logradouro = end.Logradouro,
//                                                     Numero = end.Numero,
//                                                     Complemento = end.Complemento,
//                                                     Bairro = end.Bairro,
//                                                     Cidade = end.Cidade,
//                                                     Estado = end.Estado
//                                                 }).ToList()
//                            }).ToList();
//                return item;
//            }
//        }

//        public IEnumerable<PessoaJuridicaModel> PesquisarPorPerfil(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.PessoaJuridica
//                            .Include(t => t.Telefone)
//                            .Include(e => e.Endereco)
//                            .Include(pf => pf.Perfil)
//                            where p.IdPerfil == pId && p.Ativo == true
//                            select new PessoaJuridicaModel
//                            {
//                                Id = p.Id,
//                                IdPerfil = p.IdPerfil,
//                                Nome = p.Nome,
//                                CpfCnpj = p.CpfCnpj,
//                                Logo = p.Logo,
//                                Mensalidade = p.Mensalidade,
//                                DataCadastro = p.DataCadastro,
//                                Ativo = p.Ativo,
//                                PerfilModel = new PerfilModel { Id = p.Perfil.Id, Descricao = p.Perfil.Descricao },
//                                TelefoneModel = (from tt in p.Telefone
//                                                 where tt.Ativo == true
//                                                 select new TelefoneModel
//                                                 {
//                                                     Id = tt.Id,
//                                                     IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                     Numero = tt.Numero,
//                                                 }).ToList(),
//                                EnderecoModel = (from end in p.Endereco
//                                                 where end.Ativo == true
//                                                 select new EnderecoModel
//                                                 {
//                                                     Id = end.Id,
//                                                     IdPessoaJuridica = end.IdPessoaJuridica,
//                                                     Cep = end.Cep,
//                                                     Logradouro = end.Logradouro,
//                                                     Numero = end.Numero,
//                                                     Complemento = end.Complemento,
//                                                     Bairro = end.Bairro,
//                                                     Cidade = end.Cidade,
//                                                     Estado = end.Estado
//                                                 }).ToList()
//                            }).ToList();
//                return item;
//            }
//        }

//        public IEnumerable<PessoaJuridicaModel> PesquisarPorPerfilSimplificado(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.PessoaJuridica
//                            where p.IdPerfil == pId && p.Ativo == true
//                            select new PessoaJuridicaModel
//                            {
//                                Id = p.Id,
//                                IdPerfil = p.IdPerfil,
//                                Nome = p.Nome,
//                                CpfCnpj = p.CpfCnpj,
//                                Logo = p.Logo,
//                                Mensalidade = p.Mensalidade,
//                                DataCadastro = p.DataCadastro,
//                                Ativo = p.Ativo
//                            }).ToList();
//                return item;
//            }
//        }

//        public int TotalColetasPorClienteMes(int pId, DateTime dtInicio, DateTime dtFinal)
//        {

//            using (var db = new AtenasData())
//            {
//                var lista = from c in db.Coleta
//                            join pj in db.PessoaJuridica on c.IdPessoaJuridicaCliente equals pj.Id
//                            where c.Ativo == true && pj.Id == pId && c.DataColeta >= dtInicio && c.DataColeta <= dtFinal
//                            select c;

//                return lista.Count();
//            }
//        }


//        public PessoaJuridicaModel Adicionar(PessoaJuridicaModel item)
//        {
//            var model = new PessoaJuridica
//            {
//                IdPerfil = item.IdPerfil,
//                Nome = item.Nome,
//                CpfCnpj = item.CpfCnpj,
//                Logo = item.Logo,
//                Mensalidade = item.Mensalidade,
//                DataCadastro = DateTime.Now,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.PessoaJuridica.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }
//            return item;
//        }

//        public PessoaJuridicaModel Modificar(PessoaJuridicaModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.PessoaJuridica where p.Id == item.Id select p).FirstOrDefault();
//                model.Nome = item.Nome;
//                model.CpfCnpj = item.CpfCnpj;
//                model.Logo = item.Logo;
//                model.Mensalidade = item.Mensalidade;
//                db.Entry(model).State = EntityState.Modified;
//                db.SaveChanges();
//            }
//            return item;
//        }

//        public bool Excluir(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.PessoaJuridica where p.Id == pId select p).FirstOrDefault();
//                model.Ativo = false;
                
//                db.Entry(model).State = EntityState.Modified;
//                db.SaveChanges();
//            }
//            return true;
//        }
//    }
//}
