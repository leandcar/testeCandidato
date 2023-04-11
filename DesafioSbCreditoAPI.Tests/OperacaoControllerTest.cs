using DesafioSbCreditoAPI.Controllers;
using DesafioSbCreditoAPI.Domain.Models;
using DesafioSbCreditoAPI.Domain.Services.Interfaces;
using DesafioSbCreditoAPI.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Runtime.CompilerServices;
using Xunit;

namespace DesafioSbCreditoAPI.Tests;

public class OperacaoControllerTest
{




    [Fact]
    public async Task ListarTodas_ShouldReturns200Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();

        operacaoService.Setup(x => x.ListarOperacoes())
            .ReturnsAsync(OperacaoMockData.ListarOperacoes());

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.GetAll();

        ///Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task ListarPorId_ShouldReturns200Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();
        string idOperacao = "123456789";

        operacaoService.Setup(x => x.ListarOperacaoPorId(idOperacao))
            .ReturnsAsync(OperacaoMockData.ListarOperacaoPorId(idOperacao));

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.Get(idOperacao);

        ///Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task ListarPorId_Invalido_ShouldReturns404Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();
        string idOperacao = "batatinha";

        operacaoService.Setup(x => x.ListarOperacaoPorId(idOperacao))
            .ReturnsAsync(OperacaoMockData.ListarOperacaoPorId(idOperacao));

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.Get(idOperacao);

        ///Assert
        result.GetType().Should().Be(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult).StatusCode.Should().Be(404);

    }

    [Fact]
    public async Task Adicionar_ShouldReturns201Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();

        var httpContext = new DefaultHttpContext(); 
        httpContext.Request.Path = "/api"; 

        var controllerContext = new ControllerContext()
        {
            HttpContext = httpContext,
        };

        #region criar uma instancia de Operacao
        Operacao novaOperacao = new Operacao
        {
            Id = "",
            dataCadastro = Convert.ToDateTime("2023-01-01 12:00"),
            usuarioCadastro = "Karen",
            titulos = new List<Titulo>
                {
                    new Titulo
                    {
                        cnpj              = "9879876876",
                        nomeSacado        = "Joelma",
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
                        nomeSacado        = "Monica das Dores",
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

        };

        #endregion 

        operacaoService.Setup(x => x.CadastrarOperacao(novaOperacao))
            .ReturnsAsync(OperacaoMockData.CadastrarOperacao(novaOperacao));

        var sut = new OperacaoController(operacaoService.Object) 
        { 
            ControllerContext = controllerContext
        };

        ///Act
        var result = await sut.Post(novaOperacao);

        ///Assert
        result.GetType().Should().Be(typeof(CreatedResult));
        (result as CreatedResult).StatusCode.Should().Be(201);


    }

    [Fact]
    public async Task Atualizar_ShouldReturns200Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();

        #region criar uma instancia de Operacao
        Operacao operacaoAtualizada = new Operacao
        {
            Id = "64342f3bb928c22af5c0fd17",
            dataCadastro = Convert.ToDateTime("2023-01-01 12:00"),
            usuarioCadastro = "Karen",
            titulos = new List<Titulo>
                {
                    new Titulo
                    {
                        cnpj              = "9879876876",
                        nomeSacado        = "Joelma",
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
                        nomeSacado        = "Monica das Dores",
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

        };

        #endregion 

        operacaoService.Setup(x => x.ListarOperacaoPorId(operacaoAtualizada.Id))
            .ReturnsAsync(OperacaoMockData.ListarOperacaoPorId(operacaoAtualizada.Id));

        operacaoService.Setup(x => x.AtualizarOperacao(operacaoAtualizada))
            .ReturnsAsync(OperacaoMockData.Atualizar(operacaoAtualizada));

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.Put(operacaoAtualizada);

        ///Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);


    }

    public void Atualizar_OperacaoNaoCadastrada()
    {

    }

    [Fact]
    public async Task Apagar_ShouldReturns204Status()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();
        string idOperacao = "64342f3bb928c22af5c0fd17";

        operacaoService.Setup(x => x.ListarOperacaoPorId(idOperacao))
            .ReturnsAsync(OperacaoMockData.ListarOperacaoPorId(idOperacao));

        operacaoService.Setup(x => x.ApagarOperacao(idOperacao))
            .ReturnsAsync(OperacaoMockData.Apagar(idOperacao));

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.Delete(idOperacao);

        ///Assert
        result.GetType().Should().Be(typeof(NoContentResult));
        (result as NoContentResult).StatusCode.Should().Be(204);

    }

    [Fact]
    public async Task Apagar_OpercaoNaoCadastrada_ShouldReturns404StatusAsync()
    {
        ///Arrange
        var operacaoService = new Mock<IOperacaoService>();
        string idOperacao = "batatinha";

        operacaoService.Setup(x => x.ListarOperacaoPorId(idOperacao))
            .ReturnsAsync(OperacaoMockData.ListarOperacaoPorId(idOperacao));

        operacaoService.Setup(x => x.ApagarOperacao(idOperacao))
            .ReturnsAsync(OperacaoMockData.Apagar(idOperacao));

        var sut = new OperacaoController(operacaoService.Object);

        ///Act
        var result = await sut.Delete(idOperacao);

        ///Assert
        result.GetType().Should().Be(typeof(NotFoundObjectResult));
        (result as NotFoundObjectResult).StatusCode.Should().Be(404);

    }
}