namespace Phoenix.Infrastructure.Dapper
{
    public interface IBaseRepository
    {
        ///// <summary>
        ///// Gets the current session in the repository.
        ///// </summary>
        ///// <returns>Current session.</returns>
        //ISession GetCurrentSession();

        ///// <summary>
        ///// Finds an entity by passed identifier.
        ///// </summary>
        ///// <param name="id">Identifier.</param>
        ///// <returns>Entity matching identifier.</returns>
        //TEntity FindById(TKey id);

        ///// <summary>
        ///// Saves entity.
        ///// </summary>
        ///// <param name="t">Entity to save.</param>
        //void Save(TEntity t);

        ///// <summary>
        ///// Saves or updates entity.
        ///// </summary>
        ///// <param name="t">Entity to save or update.</param>
        //TEntity SaveOrUpdate(TEntity t);

        ///// <summary>
        ///// Deletes entity.
        ///// </summary>
        ///// <param name="t">Entity to delete.</param>
        //void Delete(TEntity t);

        ///// <summary>
        ///// Deletes entity.
        ///// </summary>
        ///// <param name="entities">Entities to delete.</param>
        //void DeleteAll(IList<TEntity> entities);

        ///// <summary>
        ///// Deletes entity.
        ///// </summary>
        ///// <param name="id"><b>Id Value to be deleted</b></param>
        ///// <param name="idName"><b>Cloumn Name need to check</b></param>
        //void Delete(TKey id, string idName);

        ///// <summary>
        ///// Finds all entities and passes back as a collection.
        ///// </summary>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindAll();

        ///// <summary>
        ///// Finds all entities by passed order and passes back as a collection.
        ///// </summary>
        ///// <param name="orders">Orders.</param>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindAll(params Order[] orders);

        ///// <summary>
        ///// Finds all entities and passes back as a collection within the range specified.
        ///// </summary>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <returns>Collection of entities.</returns>
        //PagedResult<TEntity> FindAll(int firstResult, int numberOfResults);

        ///// <summary>
        ///// Finds all entities and passes back as a collection within the range specified.
        ///// </summary>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <param name="orders">Orders.</param>
        ///// <returns>Collection of entities.</returns>
        //PagedResult<TEntity> FindAll(int firstResult, int numberOfResults, params Order[] orders);

        ///// <summary>
        ///// Finds all entities and passes back as a collection within the range specified.
        ///// </summary>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results.</param>
        ///// <param name="sortFields">Sort order dictionary.</param>
        ///// <returns>List of entities.</returns>
        //IList<TEntity> FindAll(int firstResult, int numberOfResults, IDictionary<string, bool> sortFields);

        ///// <summary>
        ///// Finds entities by criteria.
        ///// </summary>
        ///// <param name="dc">Detatched criteria.</param>
        ///// <returns>Collection of entities that match the passed criteria.</returns>
        //IList<TEntity> FindByCriteria(DetachedCriteria dc);

        ///// <summary>
        ///// Finds entities by criteria and paging.
        ///// </summary>
        ///// <param name="dc">Detatched criteria.</param>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <returns>Collection of entities that match the passed criteria.</returns>
        //PagedResult<TEntity> FindByCriteria(DetachedCriteria dc, int firstResult, int numberOfResults);

        ///// <summary>
        ///// Finds entities by criteria, paging and ordering.
        ///// </summary>
        ///// <param name="dc">Detatched criteria.</param>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <param name="orders">Orders.</param>
        ///// <returns>Collection of entities that match the passed criteria.</returns>
        //PagedResult<TEntity> FindByCriteria(DetachedCriteria dc, int firstResult, int numberOfResults, params Order[] orders);

        ///// <summary>
        ///// Gets a list of entities by passed query.
        ///// </summary>
        ///// <param name="queryString">Query to get entities.</param>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindByQuery(string queryString);

        ///// <summary>
        ///// Gets a list of entities by passed query and parameters.
        ///// </summary>
        ///// <param name="queryString">Query to get entities.</param>
        ///// <param name="parameters">Parameters to set in query.</param>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindByQuery(string queryString, params object[] parameters);

        ///// <summary>
        ///// Gets a list of entities by passed query.
        ///// </summary>
        ///// <param name="queryString">Query to get entities.</param>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindByQuery(string queryString, int firstResult, int numberOfResults);

        ///// <summary>
        ///// Gets a list of entities by passed query and parameters.
        ///// </summary>
        ///// <param name="queryString">Query to get entities.</param>
        ///// <param name="firstResult">First result.</param>
        ///// <param name="numberOfResults">Number of results to return.</param>
        ///// <param name="parameters">Parameters to set in query.</param>
        ///// <returns>Collection of entities.</returns>
        //IList<TEntity> FindByQuery(string queryString, int firstResult, int numberOfResults, params object[] parameters);

        ///// <summary>
        ///// Finds one entity that matches criteria and throws exception otherwise.
        ///// </summary>
        ///// <param name="criteria">Criteria.</param>
        ///// <returns>Entity matching criteria.</returns>
        //TEntity FindOne(DetachedCriteria criteria);

        ///// <summary>
        ///// Finds first entity in collection that matches criteria.
        ///// </summary>
        ///// <param name="criteria">Criteria.</param>
        ///// <returns>First entity.</returns>
        //TEntity FindFirst(DetachedCriteria criteria);

        ///// <summary>
        ///// Finds first entity in collection that matches criteria and order params.
        ///// </summary>
        ///// <param name="criteria">Criteria.</param>
        ///// <param name="orders">Orders.</param>
        ///// <returns>First entity.</returns>
        //TEntity FindFirst(DetachedCriteria criteria, params Order[] orders);

        ///// Get count of entities that match criteria
        ///// </summary>
        ///// <param name="criteria">Criteria</param>
        ///// <returns>Count of number of entities that match criteria</returns>
        //int Count(DetachedCriteria criteria);

        ///// <summary>
        ///// Get count of entities.
        ///// </summary>
        ///// <returns>Count of entities.</returns>
        //int Count();

        ///// <summary>
        ///// Determines if at least one entity exists that matches passed criteria.
        ///// </summary>
        ///// <param name="criteria">Criteria.</param>
        ///// <returns><c>true</c> if exists.</returns>
        //bool Exists(DetachedCriteria criteria);
    }
}
