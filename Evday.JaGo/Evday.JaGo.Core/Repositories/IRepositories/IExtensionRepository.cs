using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.Core.IRepositories
{
    /// <summary>
    /// 扩展的Repository操作规范
    /// 大批量数据一次性添加，删除，修改 一次savechange
    /// </summary>
    public interface IExtensionRepository : IRepository
    {
        #region 行为操作
        /// <summary>
        /// 添加集合[集合数目不大时用此方法，超大集合使用BulkInsert]
        /// </summary>
        /// <param name="item"></param>
        void Insert<TEntity>(IEnumerable<TEntity> item) where TEntity : class;
        /// <summary>
        /// 修改集合[集合数目不大时用此方法，超大集合使用BulkUpdate]
        /// </summary>
        /// <param name="item"></param>
        void Update<TEntity>(IEnumerable<TEntity> item) where TEntity : class;
        /// <summary>
        /// 删除集合[集合数目不大时用此方法，超大集合使用批量删除]
        /// </summary>
        /// <param name="item"></param>
        void Delete<TEntity>(IEnumerable<TEntity> item) where TEntity : class;
        /// <summary>
        /// 批量添加，添加之前可以去除自增属性,默认不去除
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isRemoveIdentity"></param>
        void BulkInsert<TEntity>(IEnumerable<TEntity> item, bool isRemoveIdentity) where TEntity : class;

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="item"></param>
        void BulkInsert<TEntity>(IEnumerable<TEntity> item) where TEntity : class;

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="item"></param>
        void BulkUpdate<TEntity>(IEnumerable<TEntity> item, params string[] fieldParams) where TEntity : class;

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="item"></param>
        void BulkDelete<TEntity>(IEnumerable<TEntity> item) where TEntity : class;
        #endregion

        #region 查询操作
        /// <summary>
        /// 根据指定lambda表达式,得到延时结果集
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetModel<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        /// <summary>
        /// 根据指定lambda表达式,得到第一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        #endregion
    }
}
