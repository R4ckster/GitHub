
//using Model;
//using System;
//using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class DespachoModel : IRepository<DespachoModel>
//    {
//        public int Id { get; set; }        
//        public string NomeMotorista { get; set; }        
//        public string Documento { get; set; }        
//        public string Placa { get; set; }        
//        public string CidadeUF { get; set; }
//        public DateTime? DataDespacho { get; set; }
//        public bool? Ativo { get; set; }
//        public List<ColetaModel> Coletas { get; set; }
//        public int[] ColetasParaDespacho { get; set; }

//        public IEnumerable<DespachoModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from p in db.Despacho
//                            where p.Ativo == true
//                            select new DespachoModel
//                            {
//                                Id = p.Id,
//                                NomeMotorista = p.NomeMotorista,
//                                Documento = p.Documento,
//                                Placa = p.Placa,
//                                CidadeUF = p.CidadeUF,
//                                DataDespacho = p.DataDespacho,
//                                Ativo = p.Ativo
//                            }).ToList();
//                return item;
//            }            
//        }

//        public DespachoModel PesquisarPorId(int id)
//        {            
//            using (var db = new AtenasData())
//            {
//                var item = (from d in db.Despacho                             
//                             where d.Id == id
//                             select new DespachoModel
//                             {
//                                 Id = d.Id,
//                                 Documento = d.Documento,
//                                 NomeMotorista = d.NomeMotorista,
//                                 Placa = d.Placa,
//                                 CidadeUF = d.CidadeUF,
//                                 DataDespacho = d.DataDespacho.Value
//                             }).FirstOrDefault();

//                if (item != null)
//                {
//                    item.Coletas = (from dc in db.DespachoColeta
//                                    join c in db.Coleta on dc.IdColeta equals c.Id
//                                    where dc.IdDespacho == item.Id
//                                    select new ColetaModel
//                                    {
//                                        Id = c.Id,
//                                        IdPessoaJuridicaCliente = c.IdPessoaJuridicaCliente,
//                                        IdPessoaJuridicaRemetente = c.IdPessoaJuridicaRemetente,
//                                        IdPessoaJuridicaDestinatario = c.IdPessoaJuridicaDestinatario,
//                                        IdStatus = c.IdStatus,
//                                        IdTransporte = c.IdTransporte,
//                                        DescricaoTransporte = c.Transporte.Descricao,
//                                        Quantidade = c.Quantidade,
//                                        Peso = c.Peso,
//                                        NumeroNF = c.NumeroNF,
//                                        Valor = c.Valor,
//                                        Obs = c.Obs,
//                                        DataColeta = c.DataColeta,
//                                        DataCadastro = c.DataCadastro,
//                                        Ativo = c.Ativo,
//                                        Cliente = (from cli in db.PessoaJuridica
//                                                   where cli.Id == c.IdPessoaJuridicaCliente
//                                                   select new PessoaJuridicaModel
//                                                   {
//                                                       Id = cli.Id,
//                                                       IdPerfil = cli.IdPerfil,
//                                                       Nome = cli.Nome,
//                                                       CpfCnpj = cli.CpfCnpj,
//                                                       Logo = cli.Logo,
//                                                       Mensalidade = cli.Mensalidade,
//                                                       DataCadastro = cli.DataCadastro,
//                                                       Ativo = cli.Ativo,
//                                                       TelefoneModel = (from tt in db.Telefone
//                                                                        where tt.IdPessoaJuridica == c.IdPessoaJuridicaCliente
//                                                                        && tt.Ativo == true
//                                                                        select new TelefoneModel
//                                                                        {
//                                                                            Id = tt.Id,
//                                                                            IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                            Numero = tt.Numero,
//                                                                        }).ToList(),
//                                                       EnderecoModel = (from end in db.Endereco
//                                                                        where end.IdPessoaJuridica == c.IdPessoaJuridicaCliente
//                                                                        && end.Ativo == true
//                                                                        select new EnderecoModel
//                                                                        {
//                                                                            Id = end.Id,
//                                                                            IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                            Cep = end.Cep,
//                                                                            Logradouro = end.Logradouro,
//                                                                            Numero = end.Numero,
//                                                                            Complemento = end.Complemento,
//                                                                            Bairro = end.Bairro,
//                                                                            Cidade = end.Cidade,
//                                                                            Estado = end.Estado
//                                                                        }).ToList()
//                                                   }).FirstOrDefault(),
//                                        Remetente = (from cli in db.PessoaJuridica
//                                                     where cli.Id == c.IdPessoaJuridicaRemetente
//                                                     select new PessoaJuridicaModel
//                                                     {
//                                                         Id = cli.Id,
//                                                         IdPerfil = cli.IdPerfil,
//                                                         Nome = cli.Nome,
//                                                         CpfCnpj = cli.CpfCnpj,
//                                                         Logo = cli.Logo,
//                                                         Mensalidade = cli.Mensalidade,
//                                                         DataCadastro = cli.DataCadastro,
//                                                         Ativo = cli.Ativo,
//                                                         TelefoneModel = (from tt in db.Telefone
//                                                                          where tt.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
//                                                                          && tt.Ativo == true
//                                                                          select new TelefoneModel
//                                                                          {
//                                                                              Id = tt.Id,
//                                                                              IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                              Numero = tt.Numero,
//                                                                          }).ToList(),
//                                                         EnderecoModel = (from end in db.Endereco
//                                                                          where end.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
//                                                                          && end.Ativo == true
//                                                                          select new EnderecoModel
//                                                                          {
//                                                                              Id = end.Id,
//                                                                              IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                              Cep = end.Cep,
//                                                                              Logradouro = end.Logradouro,
//                                                                              Numero = end.Numero,
//                                                                              Complemento = end.Complemento,
//                                                                              Bairro = end.Bairro,
//                                                                              Cidade = end.Cidade,
//                                                                              Estado = end.Estado
//                                                                          }).ToList()
//                                                     }).FirstOrDefault(),
//                                        Destinatario = (from cli in db.PessoaJuridica
//                                                        where cli.Id == c.IdPessoaJuridicaDestinatario
//                                                        select new PessoaJuridicaModel
//                                                        {
//                                                            Id = cli.Id,
//                                                            IdPerfil = cli.IdPerfil,
//                                                            Nome = cli.Nome,
//                                                            CpfCnpj = cli.CpfCnpj,
//                                                            Logo = cli.Logo,
//                                                            Mensalidade = cli.Mensalidade,
//                                                            DataCadastro = cli.DataCadastro,
//                                                            Ativo = cli.Ativo,
//                                                            TelefoneModel = (from tt in db.Telefone
//                                                                             where tt.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
//                                                                             && tt.Ativo == true
//                                                                             select new TelefoneModel
//                                                                             {
//                                                                                 Id = tt.Id,
//                                                                                 IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                                 Numero = tt.Numero,
//                                                                             }).ToList(),
//                                                            EnderecoModel = (from end in db.Endereco
//                                                                             where end.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
//                                                                             && end.Ativo == true
//                                                                             select new EnderecoModel
//                                                                             {
//                                                                                 Id = end.Id,
//                                                                                 IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                                 Cep = end.Cep,
//                                                                                 Logradouro = end.Logradouro,
//                                                                                 Numero = end.Numero,
//                                                                                 Complemento = end.Complemento,
//                                                                                 Bairro = end.Bairro,
//                                                                                 Cidade = end.Cidade,
//                                                                                 Estado = end.Estado
//                                                                             }).ToList()
//                                                        }).FirstOrDefault()
//                                    }).ToList();
//                }
//                return item;
//            }
//        }

//        public DespachoModel Adicionar(DespachoModel item)
//        {
//            var model = new Despacho
//            {
//                NomeMotorista = item.NomeMotorista,
//                Documento = item.Documento,
//                Placa = item.Placa,
//                CidadeUF = item.CidadeUF,
//                DataDespacho = item.DataDespacho,             
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Despacho.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;
//            }

//            foreach(var des in item.ColetasParaDespacho)
//            {
//                var model2 = new DespachoColeta
//                {
//                    IdDespacho = model.Id,
//                    IdColeta = des,
//                    Ativo = true
//                };
//                using (var db = new AtenasData())
//                {
//                    db.DespachoColeta.Add(model2);
//                    db.SaveChanges();                    
//                }

//                using (var db = new AtenasData())
//                {
//                    var coleta = (from c in db.Coleta
//                                 where c.Id == des
//                                 select c).FirstOrDefault();

//                    coleta.IdStatus = 3;
//                    db.Entry(coleta).State = EntityState.Modified;
//                    db.SaveChanges();
//                }


//            }
//            return item;
//        }

//        public DespachoModel Modificar(DespachoModel item)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Excluir(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public List<ColetaModel> PesquisarPorCodigoClienteEStatusColetado(int id)
//        {            
//            using (var db = new AtenasData())
//            {
//                var listaModel = (from c in db.Coleta                                    
//                            where c.Ativo == true && c.IdPessoaJuridicaCliente == id && c.IdStatus == 2
//                            && c.Ativo == true
//                            select new ColetaModel
//                            {
//                                Id = c.Id,
//                                IdPessoaJuridicaCliente = c.IdPessoaJuridicaCliente,
//                                IdPessoaJuridicaRemetente = c.IdPessoaJuridicaRemetente,
//                                IdPessoaJuridicaDestinatario = c.IdPessoaJuridicaDestinatario,
//                                IdStatus = c.IdStatus,
//                                IdTransporte = c.IdTransporte,
//                                DescricaoTransporte = c.Transporte.Descricao,
//                                Quantidade = c.Quantidade,
//                                Peso = c.Peso,
//                                NumeroNF = c.NumeroNF,
//                                Valor = c.Valor,
//                                Obs = c.Obs,
//                                DataColeta = c.DataColeta,
//                                DataCadastro = c.DataCadastro,
//                                Ativo = c.Ativo,
//                                Cliente = (from cli in db.PessoaJuridica
//                                           where cli.Id == c.IdPessoaJuridicaCliente
//                                           select new PessoaJuridicaModel
//                                           {
//                                               Id = cli.Id,
//                                               IdPerfil = cli.IdPerfil,
//                                               Nome = cli.Nome,
//                                               CpfCnpj = cli.CpfCnpj,
//                                               Logo = cli.Logo,
//                                               Mensalidade = cli.Mensalidade,
//                                               DataCadastro = cli.DataCadastro,
//                                               Ativo = cli.Ativo,
//                                               TelefoneModel = (from tt in db.Telefone
//                                                                where tt.IdPessoaJuridica == c.IdPessoaJuridicaCliente
//                                                                && tt.Ativo == true
//                                                                select new TelefoneModel
//                                                                {
//                                                                    Id = tt.Id,
//                                                                    IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                    Numero = tt.Numero,
//                                                                }).ToList(),
//                                               EnderecoModel = (from end in db.Endereco
//                                                                where end.IdPessoaJuridica == c.IdPessoaJuridicaCliente
//                                                                && end.Ativo == true
//                                                                select new EnderecoModel
//                                                                {
//                                                                    Id = end.Id,
//                                                                    IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                    Cep = end.Cep,
//                                                                    Logradouro = end.Logradouro,
//                                                                    Numero = end.Numero,
//                                                                    Complemento = end.Complemento,
//                                                                    Bairro = end.Bairro,
//                                                                    Cidade = end.Cidade,
//                                                                    Estado = end.Estado
//                                                                }).ToList()
//                                           }).FirstOrDefault(),
//                                Remetente = (from cli in db.PessoaJuridica
//                                             where cli.Id == c.IdPessoaJuridicaRemetente
//                                             select new PessoaJuridicaModel
//                                             {
//                                                 Id = cli.Id,
//                                                 IdPerfil = cli.IdPerfil,
//                                                 Nome = cli.Nome,
//                                                 CpfCnpj = cli.CpfCnpj,
//                                                 Logo = cli.Logo,
//                                                 Mensalidade = cli.Mensalidade,
//                                                 DataCadastro = cli.DataCadastro,
//                                                 Ativo = cli.Ativo,
//                                                 TelefoneModel = (from tt in db.Telefone
//                                                                  where tt.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
//                                                                  && tt.Ativo == true
//                                                                  select new TelefoneModel
//                                                                  {
//                                                                      Id = tt.Id,
//                                                                      IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                      Numero = tt.Numero,
//                                                                  }).ToList(),
//                                                 EnderecoModel = (from end in db.Endereco
//                                                                  where end.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
//                                                                  && end.Ativo == true
//                                                                  select new EnderecoModel
//                                                                  {
//                                                                      Id = end.Id,
//                                                                      IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                      Cep = end.Cep,
//                                                                      Logradouro = end.Logradouro,
//                                                                      Numero = end.Numero,
//                                                                      Complemento = end.Complemento,
//                                                                      Bairro = end.Bairro,
//                                                                      Cidade = end.Cidade,
//                                                                      Estado = end.Estado
//                                                                  }).ToList()
//                                             }).FirstOrDefault(),
//                                Destinatario = (from cli in db.PessoaJuridica
//                                                where cli.Id == c.IdPessoaJuridicaDestinatario
//                                                select new PessoaJuridicaModel
//                                                {
//                                                    Id = cli.Id,
//                                                    IdPerfil = cli.IdPerfil,
//                                                    Nome = cli.Nome,
//                                                    CpfCnpj = cli.CpfCnpj,
//                                                    Logo = cli.Logo,
//                                                    Mensalidade = cli.Mensalidade,
//                                                    DataCadastro = cli.DataCadastro,
//                                                    Ativo = cli.Ativo,
//                                                    TelefoneModel = (from tt in db.Telefone
//                                                                     where tt.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
//                                                                     && tt.Ativo == true
//                                                                     select new TelefoneModel
//                                                                     {
//                                                                         Id = tt.Id,
//                                                                         IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                         Numero = tt.Numero,
//                                                                     }).ToList(),
//                                                    EnderecoModel = (from end in db.Endereco
//                                                                     where end.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
//                                                                     && end.Ativo == true
//                                                                     select new EnderecoModel
//                                                                     {
//                                                                         Id = end.Id,
//                                                                         IdPessoaJuridica = end.IdPessoaJuridica,
//                                                                         Cep = end.Cep,
//                                                                         Logradouro = end.Logradouro,
//                                                                         Numero = end.Numero,
//                                                                         Complemento = end.Complemento,
//                                                                         Bairro = end.Bairro,
//                                                                         Cidade = end.Cidade,
//                                                                         Estado = end.Estado
//                                                                     }).ToList()
//                                                }).FirstOrDefault()
//                            }).ToList();
//                return listaModel;
//            }
//        }
//    }
//}
