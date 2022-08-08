namespace FishingTrip.Application.Interface
{
    public interface IDbContextProvider<out TDbContext>
    {
        TDbContext Get();
    }
}