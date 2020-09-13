namespace ProvaF.Infrastructure.Data
{
    public class BaseRepository
    {
        protected readonly ProvaFDbContext _context;

        protected BaseRepository(ProvaFDbContext context)
        {
            _context = context;
        }
    }
}