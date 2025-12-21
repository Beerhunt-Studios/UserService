using System.Threading.Tasks;
using AutoMapper;
using BaseChord.Application.Database;
using BaseChord.Contracts.Stammdaten.MusicGenre;
using MassTransit;
using Microsoft.Extensions.Logging;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Hilfstexte;

namespace UserService.Application.Eventbus.MusicGenreAddedEvent;

public class MusicGenreAddedConsumer : IConsumer<MusicGenreAdded>
{
    private readonly ILogger<MusicGenreAddedConsumer> _logger;
    private readonly IMusicGenreRepository _musicGenreRepository;
    private readonly IMapper _mapper;
    private readonly IDbTransactionFactory _dbTransactionFactory;

    public MusicGenreAddedConsumer(ILogger<MusicGenreAddedConsumer> logger, IMusicGenreRepository musicGenreRepository, IMapper mapper, IDbTransactionFactory dbTransactionFactory)
    {
        _logger = logger;
        _musicGenreRepository = musicGenreRepository;
        _mapper = mapper;
        _dbTransactionFactory = dbTransactionFactory;
    }

    public async Task Consume(ConsumeContext<MusicGenreAdded> context)
    {
        using IDbTransaction dbTransaction = await _dbTransactionFactory.CreateTransaction();

        await _musicGenreRepository.AddAsync(_mapper.Map<MusicGenre>(context.Message));
        await dbTransaction.CommitAsync(context.CancellationToken);
    }
}
