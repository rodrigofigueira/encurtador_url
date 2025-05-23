namespace Infrastructure.Repositories.DapperSQLite;

public class UrlRepositoryDapper(IDbConnection connection) : IUrlRepository
{
    public async Task<UrlEntity> Post(UrlEntity entity)
    {
        string query = @"INSERT INTO Urls(Alias, Original)                         
                         VALUES (@Alias, @Original);
                         SELECT last_insert_rowid();";
        entity.Id = await connection.ExecuteScalarAsync<int>(query, entity);
        return entity;
    }

    public async Task<bool> Put(UrlEntity entity)
    {
        string query = @"UPDATE Urls
                         SET Alias = @Alias
                             ,Original = @Original
                         WHERE Id = @Id";
        int rowsAfected = await connection.ExecuteAsync(query, entity);
        return rowsAfected > 0;
    }
}
