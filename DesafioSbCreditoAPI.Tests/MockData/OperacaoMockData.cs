using DesafioSbCreditoAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSbCreditoAPI.Tests.MockData;

public class OperacaoMockData
{

    public static IEnumerable<Operacao> ListarOperacoes()
    {

        return new List<Operacao>
        {
            new Operacao{
                Id = "123456789",
                dataCadastro = Convert.ToDateTime("2023-01-01 12:00"),
                usuarioCadastro = "Ariane",
                titulos = new List<Titulo>
                {
                    new Titulo
                    {
                        cnpj              = "74129074132847",
                        nomeSacado        = "Marta De Cassia",
                        telefoneSacado    = "13987686547",
                        cep               = "09876010",
                        enderecoCobranca  = "Rua Das Caldeiras",
                        estado            = "SP",
                        cidade            = "Santos",
                        bairro            = "Caldeiras",
                        dataEmissao       = Convert.ToDateTime("2020-01-01 12:00"),
                        dataVencimento    = Convert.ToDateTime("2021-01-01 12:00"),
                        valorDesconto     = 43,
                        valorFace         = 2300,
                        seuNumero         = 1234567890
                    },
                                        new Titulo
                    {
                        cnpj              = "98986587686",
                        nomeSacado        = "Maria De Cassia",
                        telefoneSacado    = "21987686590",
                        cep               = "09096020",
                        enderecoCobranca  = "Rua do Telegrafo",
                        estado            = "RJ",
                        cidade            = "Rio de Janeiro",
                        bairro            = "Correio",
                        dataEmissao       = Convert.ToDateTime("2020-01-01 12:00"),
                        dataVencimento    = Convert.ToDateTime("2021-01-01 12:00"),
                        valorDesconto     = 100,
                        valorFace         = 2000,
                        seuNumero         = 989076897
                    },
                }
            },

            new Operacao{
                Id = "64342f3bb928c22af5c0fd17",
                dataCadastro = Convert.ToDateTime("2023-01-01 12:00"),
                usuarioCadastro = "Karla",
                titulos = new List<Titulo>
                {
                    new Titulo
                    {
                        cnpj              = "9879876876",
                        nomeSacado        = "Monique Ribeiro",
                        telefoneSacado    = "81987686999",
                        cep               = "09876040",
                        enderecoCobranca  = "Rua Do Frevo",
                        estado            = "PE",
                        cidade            = "Olinda",
                        bairro            = "Alto da Serra",
                        dataEmissao       = Convert.ToDateTime("2020-01-01 12:00"),
                        dataVencimento    = Convert.ToDateTime("2021-01-01 12:00"),
                        valorDesconto     = 55,
                        valorFace         = 2590,
                        seuNumero         = 00001
                    },
                                        new Titulo
                    {
                        cnpj              = "98986587686",
                        nomeSacado        = "Maria das Dores",
                        telefoneSacado    = "21976812345",
                        cep               = "09096020",
                        enderecoCobranca  = "Rua do Boticario",
                        estado            = "RJ",
                        cidade            = "Rio de Janeiro",
                        bairro            = "Boticario",
                        dataEmissao       = Convert.ToDateTime("2020-01-01 12:00"),
                        dataVencimento    = Convert.ToDateTime("2021-01-01 12:00"),
                        valorDesconto     = 150,
                        valorFace         = 2300,
                        seuNumero         = 00003
                    },
                }
            }
        };

    }


    public static Operacao ListarOperacaoPorId(string id)
    {

        return ListarOperacoes().FirstOrDefault(x => x.Id == id);

    }

    public static string Apagar(string idOperacao)
    {
        var retorno = "Sucesso";
        var localizarOperacao = ListarOperacaoPorId(idOperacao);

        if(localizarOperacao == null)
        {
            retorno =  $"Operacao ({idOperacao}) não existe.";
        }

        //Apagar a operacao Localizada

        return retorno;

    }


    public static string Atualizar(Operacao operacao)
    {
        var retorno = "Sucesso";
        var localizarOperacao = ListarOperacaoPorId(operacao.Id);

        if (localizarOperacao == null)
        {
            retorno = $"Operacao ({operacao.Id}) não existe.";
        }

        //Atualizar a operacao

        return retorno;
    }

    public static string CadastrarOperacao(Operacao novaOperacao)
    {
        //Retorna o id da operacao Cadastrara
        return "64342f3bb928c22af5c00001";
    }

}
