namespace Service.Data;

public static class EntityExtensions
{
    public static IQueryable<TEntity> NotDeleted<TEntity>(this IQueryable<TEntity> entities) where TEntity : BaseEntity
    {
        return entities.Where(entity => !entity.IsDeleted);
    }
}