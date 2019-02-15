using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.Core.IRepositories
{
    /// <summary>
    /// 基本仓储操作接口
    /// out表示类型的协变,可以进行子类与父类的返回类型转换,in表示逆变
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository
    {
        /// <summary>
        /// 通过主键拿一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find<TEntity>(params object[] id) where TEntity : class;
        /// <summary>
        /// 拿到可查询结果集
        /// </summary>
        /// <returns></returns>
        System.Linq.IQueryable<TEntity> GetModel<TEntity>() where TEntity : class;
        /// <summary>
        /// 设置当前数据库上下文对象，与具体ORM无关，上下文应该继承Lind.DDD.UnitOfWork.IDataContext
        /// </summary>
        void SetDataContext(object db);
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="item"></param>
        void Insert<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="item"></param>
        void Update<TEntity>(TEntity item) where TEntity : class;
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="item"></param>
        void Delete<TEntity>(TEntity item) where TEntity : class;
    }
}
