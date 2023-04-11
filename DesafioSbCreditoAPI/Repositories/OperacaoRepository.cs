using DesafioSbCreditoAPI.Domain.Models;
using DesafioSbCreditoAPI.Infra.Data;
using DesafioSbCreditoAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace DesafioSbCreditoAPI.Repositories;

public class OperacaoRepository : BaseRepository<Operacao>, IOperacaoRepository
{

	public OperacaoRepository(IOptions<MongoDbConfig> options) 
		: base(options, "OperacaoCollection")
	{

	}

}
