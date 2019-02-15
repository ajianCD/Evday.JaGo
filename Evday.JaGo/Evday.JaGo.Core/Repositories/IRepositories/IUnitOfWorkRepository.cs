using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.Core.IRepositories
{
    /// <summary>
    /// 工作单元中仓储接口CRUD操作
    /// 需要使用工作单元的仓储，需要实现本接口（IRepository,IExtensionRepository)
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="item"></param>
        void UoWInsert<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="item"></param>
        void UoWUpdate<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="item"></param>
        void UoWDelete<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="item"></param>
        void UoWInsert<TEntity>(IEnumerable<TEntity> list) where TEntity : class;
        /// <summary>
        /// 更新集合
        /// </summary>
        /// <param name="item"></param>
        void UoWUpdate<TEntity>(IEnumerable<TEntity> list) where TEntity : class;
        /// <summary>
        /// 移除集合
        /// </summary>
        /// <param name="item"></param>
        void UoWDelete<TEntity>(IEnumerable<TEntity> list) where TEntity : class;
    }
}
