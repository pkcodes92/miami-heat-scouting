// <copyright file="DbContextExtensions.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class will have all of the necessary extension methods for the database layer.
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// This method will take the necessary SQL query and execute it.
        /// </summary>
        /// <typeparam name="T">The generic class type.</typeparam>
        /// <param name="db">The database context.</param>
        /// <param name="sql">The SQL query string to execute.</param>
        /// <param name="parameters">The input parameters required.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of generic types which would be the return model.</returns>
        public static async Task<List<T>> SqlQueryAsync<T>(this DbContext db, string sql, object[] parameters = null!, CancellationToken cancellationToken = default)
            where T : class
        {
            if (parameters is null)
            {
                parameters = new object[] { };
            }

            if (typeof(T).GetProperties().Any())
            {
                return await db.Set<T>().FromSqlRaw(sql, parameters).ToListAsync(cancellationToken);
            }
            else
            {
                await db.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
                return default!;
            }
        }
    }
}
