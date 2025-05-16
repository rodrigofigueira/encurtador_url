namespace Infrastructure.Repositories.DapperSQLite;

public class UrlRepositoryDapper(IDbConnection connection) : IUrlRepository
{
    public async Task<UrlEntity> Post(UrlEntity entity)
    {
        string query = @"INSERT INTO Urls(Alias, Original)                         
                         VALUES (@Alias, @Original);
                         SELECT last_insert_rowid();
                        ";
        entity.Id = await connection.ExecuteScalarAsync<int>(query, entity);
        return entity;
    }

}
