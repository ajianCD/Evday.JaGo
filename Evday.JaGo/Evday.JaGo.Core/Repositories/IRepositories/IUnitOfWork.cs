using Evday.JaGo.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.Core.Repositories
{
    /// <summary>
    /// 工作单元（实现事务级别操作）
    /// 所有数据上下文对象都应该继承它，面向仓储的上下文应该与具体实现（存储介质,ORM）无关
    /// </summary>
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        /// <summary>
        /// 向工作单元中注册变更的实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="type">类型</param>
        /// <param name="repository">仓储</param>
        /// <param name="action">回调方法</param>
        void RegisterChangeded(TEntity entity, SqlType type, IUnitOfWorkRepository repository, Action<TEntity> action = null);
        /// <summary>
        /// 向工作单元中注册变更的集合
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="type">类型</param>
        /// <param name="repository">仓储</param>
        /// <param name="action">回调方法</param>
        void RegisterChangeded(IEnumerable<TEntity> list, SqlType type, IUnitOfWorkRepository repository, Action<IEnumerable<TEntity>> action = null);
        /// <summary>
        /// 向数据库提交变更
        /// </summary>
        void Commit();
    }
}
