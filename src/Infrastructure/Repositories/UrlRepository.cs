namespace Infrastructure.Repositories;

public class UrlRepository(IDbConnection connection) : IUrlRepository
{
    public async Task<UrlEntity> Post(UrlEntity entity)
    {
        const string query = @"
            INSERT INTO urls(alias, original)
            VALUES (@Alias, @Original)
            RETURNING id;
        ";

        entity.Id = await connection.ExecuteScalarAsync<int>(query, entity);
        return entity;
    }

    public async Task<bool> Put(UrlEntity entity)
    {
        string query = @"UPDATE urls
                         SET alias = @Alias
                             ,original = @Original
                         WHERE id = @Id";
        int rowsAfected = await connection.ExecuteAsync(query, entity);
        return rowsAfected > 0;
    }
}
