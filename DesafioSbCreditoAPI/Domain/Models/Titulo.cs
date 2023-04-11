namespace DesafioSbCreditoAPI.Domain.Models;

public class Titulo
{
    public string? cnpj { get; set; }
    public string? nomeSacado { get; set; }
    public string? telefoneSacado { get; set; }
    public string? cep { get; set; }
    public string? enderecoCobranca { get; set; }
    public string? estado { get; set; }
    public string? cidade { get; set; }
    public string? bairro { get; set; }
    public DateTime dataEmissao { get; set; }
    public DateTime dataVencimento { get; set; }
    public decimal valorDesconto { get; set; }
    public decimal valorFace { get; set; }
    public int seuNumero { get; set; }

}
