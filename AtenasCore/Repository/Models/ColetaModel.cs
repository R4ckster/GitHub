//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository.Models
//{
//    public class ColetaModel : IRepository<ColetaModel>
//    {
//        public int Id { get; set; }
//        public int? IdPessoaJuridicaCliente { get; set; }
//        public int? IdPessoaJuridicaRemetente { get; set; }
//        public int? IdPessoaJuridicaDestinatario { get; set; }
//        public int? IdStatus { get; set; }
//        public int? IdTransporte { get; set; }
//        public string DescricaoTransporte { get; set; }
//        public int? Quantidade { get; set; }
//        public int? Peso { get; set; }        
//        public string NumeroNF { get; set; }        
//        public decimal? Valor { get; set; }
//        public string Obs { get; set; }
//        public int? QuantidadeColeta { get; set; }
//        public DateTime? DataColeta { get; set; }
//        public DateTime? DataCadastro { get; set; }
//        public bool? Ativo { get; set; }
//        public PessoaJuridicaModel Cliente { get; set; }
//        public PessoaJuridicaModel Remetente { get; set; }
//        public PessoaJuridicaModel Destinatario { get; set; }

//        public ColetaModel PesquisarPorId(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from c in db.Coleta
//                            .Include(st => st.Status)
//                            .Include(tr => tr.Transporte)
//                            where c.Id == pId
//                            select new ColetaModel
//                            {
//                                Id = c.Id,
//                                IdPessoaJuridicaCliente = c.IdPessoaJuridicaCliente,
//                                IdPessoaJuridicaRemetente = c.IdPessoaJuridicaRemetente,
//                                IdPessoaJuridicaDestinatario = c.IdPessoaJuridicaDestinatario,
//                                IdStatus = c.IdStatus,
//                                IdTransporte = c.IdTransporte,
//                                Quantidade = c.Quantidade,
//                                Peso = c.Peso,
//                                NumeroNF = c.NumeroNF,
//                                Valor = c.Valor,
//                                Obs = c.Obs,
//                                DataColeta = c.DataColeta,
//                                DataCadastro = c.DataCadastro,
//                                Ativo = c.Ativo,
//                                Cliente = (from cli in db.PessoaJuridica where cli.Id == c.IdPessoaJuridicaCliente
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
//                                           where cli.Id == c.IdPessoaJuridicaRemetente
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
//                                                                where tt.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
//                                                                && tt.Ativo == true
//                                                                select new TelefoneModel
//                                                                {
//                                                                    Id = tt.Id,
//                                                                    IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                    Numero = tt.Numero,
//                                                                }).ToList(),
//                                               EnderecoModel = (from end in db.Endereco
//                                                                where end.IdPessoaJuridica == c.IdPessoaJuridicaRemetente
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
//                                Destinatario = (from cli in db.PessoaJuridica
//                                           where cli.Id == c.IdPessoaJuridicaDestinatario
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
//                                                                where tt.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
//                                                                && tt.Ativo == true
//                                                                select new TelefoneModel
//                                                                {
//                                                                    Id = tt.Id,
//                                                                    IdPessoaJuridica = tt.IdPessoaJuridica,
//                                                                    Numero = tt.Numero,
//                                                                }).ToList(),
//                                               EnderecoModel = (from end in db.Endereco
//                                                                where end.IdPessoaJuridica == c.IdPessoaJuridicaDestinatario
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
//                                           }).FirstOrDefault()
//                            }).FirstOrDefault();
//                return item;
//            }
//        }

//        public IEnumerable<ColetaModel> PesquisarTodos()
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from c in db.Coleta                            
//                            where c.Ativo == true// && c.DataCadastro > DateTime.Now.AddYears(-1)
//                            select new ColetaModel
//                            {
//                                Id = c.Id,
//                                IdPessoaJuridicaCliente = c.IdPessoaJuridicaCliente,
//                                IdPessoaJuridicaRemetente = c.IdPessoaJuridicaRemetente,
//                                IdPessoaJuridicaDestinatario = c.IdPessoaJuridicaDestinatario,
//                                IdStatus = c.IdStatus,
//                                IdTransporte = c.IdTransporte,
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
//                return item;
//            }
//        }

//        public IEnumerable<ColetaModel> PesquisarPorStatus(int pIdStatus)
//        {
//            using (var db = new AtenasData())
//            {
//                var item = (from c in db.Coleta
//                            where c.Ativo == true && c.IdStatus == pIdStatus
//                            select new ColetaModel
//                            {
//                                Id = c.Id,
//                                IdPessoaJuridicaCliente = c.IdPessoaJuridicaCliente,
//                                IdPessoaJuridicaRemetente = c.IdPessoaJuridicaRemetente,
//                                IdPessoaJuridicaDestinatario = c.IdPessoaJuridicaDestinatario,
//                                IdStatus = c.IdStatus,
//                                IdTransporte = c.IdTransporte,
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
//                return item;
//            }
//        }

//        public IEnumerable<ColetaModel> PesquisarPorDataECliente(DateTime dataInicio, DateTime dataFim, int IdPessoaJuridicaCliente)
//        {                
//            using (var db = new AtenasData())
//            {
//                var item = (from c in db.Coleta
//                                    .Include(t => t.Transporte)
//                                    where c.DataColeta >= dataInicio && c.DataColeta <= dataFim
//                                    && c.IdPessoaJuridicaCliente == IdPessoaJuridicaCliente
//                                    && c.IdStatus != 1
//                                    && c.Ativo == true
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

//                    return item;                                
//            }
//        }

//        public ColetaModel Adicionar(ColetaModel item)
//        {
//            var model = new Coleta
//            {
//                IdPessoaJuridicaCliente = item.IdPessoaJuridicaCliente,
//                IdPessoaJuridicaRemetente = item.IdPessoaJuridicaRemetente,
//                IdPessoaJuridicaDestinatario = item.IdPessoaJuridicaDestinatario,
//                IdStatus = item.IdStatus,
//                IdTransporte = item.IdTransporte,
//                Quantidade = item.Quantidade,
//                Peso = item.Peso,
//                NumeroNF = item.NumeroNF,
//                Valor = item.Valor,
//                Obs = item.Obs,
//                DataCadastro = DateTime.Now,
//                Ativo = true
//            };
//            using (var db = new AtenasData())
//            {
//                db.Coleta.Add(model);
//                db.SaveChanges();
//                item.Id = model.Id;                
//            }

//            var repPessoa = new PessoaJuridicaModel();
//            item.Cliente = repPessoa.PesquisarPorId(item.IdPessoaJuridicaCliente.Value);
//            item.Remetente = repPessoa.PesquisarPorId(item.IdPessoaJuridicaRemetente.Value);
//            item.Destinatario = repPessoa.PesquisarPorId(item.IdPessoaJuridicaDestinatario.Value);
//            return item;
//        }

//        public ColetaModel Modificar(ColetaModel item)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Coleta where p.Id == item.Id select p).FirstOrDefault();
//                model.IdPessoaJuridicaCliente = item.IdPessoaJuridicaCliente;
//                model.IdPessoaJuridicaRemetente = item.IdPessoaJuridicaRemetente;
//                model.IdPessoaJuridicaDestinatario = item.IdPessoaJuridicaDestinatario;
//                model.DataColeta = item.DataColeta;
//                model.IdStatus = item.IdStatus;
//                model.IdTransporte = item.IdTransporte;
//                model.Quantidade = item.Quantidade;
//                model.Peso = item.Peso;
//                model.NumeroNF = item.NumeroNF;
//                model.Valor = item.Valor;
//                model.Obs = item.Obs;
//                db.Entry(model).State = EntityState.Modified;
//                db.SaveChanges();
//            }
//            var repPessoa = new PessoaJuridicaModel();
//            item.Cliente = repPessoa.PesquisarPorId(item.IdPessoaJuridicaCliente.Value);
//            item.Remetente = repPessoa.PesquisarPorId(item.IdPessoaJuridicaRemetente.Value);
//            item.Destinatario = repPessoa.PesquisarPorId(item.IdPessoaJuridicaDestinatario.Value);
//            return item;
//        }

//        public bool Excluir(int pId)
//        {
//            using (var db = new AtenasData())
//            {
//                var model = (from p in db.Coleta where p.Id == pId select p).FirstOrDefault();
//                model.Ativo = false;

//                db.Entry(model).State = EntityState.Modified;
//                db.SaveChanges();
//            }
//            return true;
//        }

//        public int TotalColetasPorClienteMes(int codigoCliente, DateTime dtInicio, DateTime dtFinal)
//        {

//            using (var db = new AtenasData())
//            {
//                var lista = from c in db.Coleta
//                            join cli in db.PessoaJuridica on c.IdPessoaJuridicaCliente equals cli.Id
//                            where c.Ativo == true && cli.Id == codigoCliente && c.DataColeta >= dtInicio && c.DataColeta <= dtFinal
//                            select c;

//                return lista.Count();
//            }
//        }


//    }
//}
