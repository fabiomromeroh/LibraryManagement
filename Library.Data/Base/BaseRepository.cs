using Data.Base;

namespace Data
{
    public abstract class BaseRepository<T> : SuperBaseRepository<LibraryContext, T>
        where T : class, new()
    {
      
    }
}
