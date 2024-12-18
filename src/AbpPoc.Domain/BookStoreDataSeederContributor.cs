using System;
using System.Threading.Tasks;
using AbpPoc.Books;
using AbpPoc.Parts;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace AbpPoc;

public class AbpPocDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly PartManager _partManager;
    private readonly IGuidGenerator _guidGenerator;

    public AbpPocDataSeederContributor(IRepository<Book, Guid> bookRepository, PartManager partManager, IGuidGenerator guidGenerator)
    {
        _bookRepository = bookRepository;
        _partManager = partManager;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );
        }


        await _partManager.CreateAsync(
            "Test Part",
            "123456",
            "1234",
            "123456",
            "123456",
            "123456",
            "123456",
            "123456",
            "123456",
            "123456"
        );

    }
}