using System.Threading.Tasks;
using AutoMapper;
using BaseChord.Application.Database;
using BaseChord.Contracts.Stammdaten.MusicGenre;
using MassTransit;
using Microsoft.Extensions.Logging;
using UserService.Application.Interfaces.Repositories;

namespace UserService.Application.Eventbus.MusicGenreDeletedEvent;

public class MusicGenreDeletedConsumer : IConsumer<MusicGenreDeleted>
{
    private readonly ILogger<MusicGenreDeletedConsumer> _logger;
    private readonly IMusicGenreRepository _musicGenreRepository;
    private readonly IDbTransactionFactory _dbTransactionFactory;

    public MusicGenreDeletedConsumer(ILogger<MusicGenreDeletedConsumer> logger, IMusicGenreRepository musicGenreRepository, IDbTransactionFactory dbTransactionFactory)
    {
        _logger = logger;
        _musicGenreRepository = musicGenreRepository;
        _dbTransactionFactory = dbTransactionFactory;
    }

    public async Task Consume(ConsumeContext<MusicGenreDeleted> context)
    {
        using IDbTransaction dbTransaction = await _dbTransactionFactory.CreateTransaction();
        await _musicGenreRepository.RemoveAsync(context.Message.Id);
        await dbTransaction.CommitAsync(context.CancellationToken);
    }
}
