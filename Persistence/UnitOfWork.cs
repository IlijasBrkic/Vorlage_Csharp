namespace Persistence;

using Core.Contracts;

using Base.Persistence;
/// <summary>
/// TODO
/// </summary>
public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    public ApplicationDbContext? ApplicationDbContext => BaseApplicationDbContext as ApplicationDbContext;

    public UnitOfWork(
        ApplicationDbContext            applicationDbContext

    ) : base(applicationDbContext)
    {

    }
}