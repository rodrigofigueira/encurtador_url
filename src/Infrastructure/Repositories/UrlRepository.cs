using static Dapper.SqlMapper;

namespace Infrastructure.Repositories;

public class UrlRepository(IDbConnection connection) : IUrlRepository
{
    public async Task<int> Count()
    {
        string query = @"SELECT count(*) as count
                         FROM public.urls;";

        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<bool> Delete(int id)
    {
        string query = @"DELETE from urls WHERE id = @id";
        int rowsAfected = await connection.ExecuteAsync(query, new { id });
        return rowsAfected > 0;
    }

    public async Task<UrlEntity> Get(int id)
    {
        string query = @"SELECT id, alias, original
                         FROM urls
                         WHERE id = @id";

        return await connection.QueryFirstAsync<UrlEntity>(query, new { id });
    }

    public async Task<IEnumerable<UrlEntity>> Get(int pageNumber, int pageSize)
    {
        string query = @"SELECT id, alias, original
                         FROM public.urls
                         ORDER BY id
                         LIMIT @pageSize OFFSET (@pageNumber - 1) * @pageSize;";

        return await connection.QueryAsync<UrlEntity>(query, new { pageNumber, pageSize });
    }

    public async Task<UrlEntity> Post(UrlEntity entity)
    {
        const string query = @"
            INSERT INTO urls(alias, original)
            VALUES (@Alias, @Original)
            RETURNING id;";

        entity.Id = await connection.ExecuteScalarAsync<int>(query, entity);
        return entity;
    }

    public async Task<bool> Put(UrlEntity entity)
    {
        string query = @"UPDATE urls
                         SET alias = @Alias, original = @Original
                         WHERE id = @Id";

        int rowsAfected = await connection.ExecuteAsync(query, entity);
        return rowsAfected > 0;
    }
}
