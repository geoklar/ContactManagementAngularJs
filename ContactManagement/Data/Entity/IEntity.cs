namespace ContactManagement.Data.Entity
{
    public interface IEntity<TKey>
    {
        TKey Identity { get; }
    }
}