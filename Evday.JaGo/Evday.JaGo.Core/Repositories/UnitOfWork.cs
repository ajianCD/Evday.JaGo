using Evday.JaGo.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Evday.JaGo.Core.Repositories
{
    /// <summary>
    /// 工作单元，主要用于管理事务性操作
    /// Author:Lind.zhang
    /// </summary>
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class 
    {
        #region Fields
        private IDictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>> insertEntities;
        private IDictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>> updateEntities;
        private IDictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>> deleteEntities;

        private IDictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>> insertListEntities;
        private IDictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>> updateListEntities;
        private IDictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>> deleteListEntities;
        #endregion

        #region Constructor
        /// <summary>
        /// 初始化
        /// </summary>
        public UnitOfWork()
        {
            insertEntities = new Dictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>>();
            updateEntities = new Dictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>>();
            deleteEntities = new Dictionary<TEntity, Tuple<IUnitOfWorkRepository, Action<TEntity>>>();
            insertListEntities = new Dictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>>();
            updateListEntities = new Dictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>>();
            deleteListEntities = new Dictionary<IEnumerable<TEntity>, Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>>();
        }

        #endregion

        #region IUnitOfWork 成员
        /// <summary>
        /// 事务提交
        /// </summary>
        public void Commit()
        {
            try
            {

                using (TransactionScope transactionScope = new TransactionScope())
                {
                    #region 提交到工作单元
                    foreach (var entity in insertEntities.Keys)
                    {
                        insertEntities[entity].Item1.UoWInsert(entity);
                        if (insertEntities[entity].Item2 != null)
                            insertEntities[entity].Item2(entity);
                    }
                    foreach (var entity in updateEntities.Keys)
                    {
                        updateEntities[entity].Item1.UoWUpdate(entity);
                        if (updateEntities[entity].Item2 != null)
                            updateEntities[entity].Item2(entity);
                    }
                    foreach (var entity in deleteEntities.Keys)
                    {
                        deleteEntities[entity].Item1.UoWDelete(entity);
                        if (deleteEntities[entity].Item2 != null)
                            deleteEntities[entity].Item2(entity);
                    }
                    foreach (var entity in insertListEntities.Keys)
                    {
                        insertListEntities[entity].Item1.UoWInsert(entity);
                        if (insertListEntities[entity].Item2 != null)
                            insertListEntities[entity].Item2(entity);
                    }
                    foreach (var entity in updateListEntities.Keys)
                    {
                        updateListEntities[entity].Item1.UoWUpdate(entity);
                        if (updateListEntities[entity].Item2 != null)
                            updateListEntities[entity].Item2(entity);
                    }
                    foreach (var entity in deleteListEntities.Keys)
                    {
                        deleteListEntities[entity].Item1.UoWDelete(entity);
                        if (deleteListEntities[entity].Item2 != null)
                            deleteListEntities[entity].Item2(entity);
                    }
                    #endregion

                    //提交事务，程序中如果出错，这行无法执行，即事务不会被提交，这就类似于rollback机制
                    transactionScope.Complete();

                    #region 清空当前上下文字典
                    insertEntities.Clear();
                    updateEntities.Clear();
                    deleteEntities.Clear();
                    insertListEntities.Clear();
                    updateListEntities.Clear();
                    deleteListEntities.Clear();
                    #endregion

                }
            }
            catch (Exception ex)
            {
                //Logger.LoggerFactory.Instance.Logger_Error(ex);
                throw ex;
            }

        }



        /// <summary>
        /// 注册数据变更实体
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="type">SQL类型</param>
        /// <param name="repository">仓储</param>
        /// <param name="action">方法回调</param>
        public void RegisterChangeded(
            TEntity entity,
            SqlType type,
            IUnitOfWorkRepository repository,
            Action<TEntity> action = null)
        {

            switch (type)
            {
                case SqlType.Insert:
                    insertEntities.Add(entity, new Tuple<IUnitOfWorkRepository, Action<TEntity>>(repository, action));
                    break;
                case SqlType.Update:
                    updateEntities.Add(entity, new Tuple<IUnitOfWorkRepository, Action<TEntity>>(repository, action));
                    break;
                case SqlType.Delete:
                    deleteEntities.Add(entity, new Tuple<IUnitOfWorkRepository, Action<TEntity>>(repository, action));
                    break;
                default:
                    throw new ArgumentException("you enter reference is error.");
            }
        }
        /// <summary>
        /// 注册数据变更集合
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <param name="repository"></param>
        public void RegisterChangeded(
            IEnumerable<TEntity> list, 
            SqlType type,
            IUnitOfWorkRepository repository,
            Action<IEnumerable<TEntity>> action = null)
        {
            switch (type)
            {
                case SqlType.Insert:
                    insertListEntities.Add(list, new Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>(repository, action));
                    break;
                case SqlType.Update:
                    updateListEntities.Add(list, new Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>(repository, action));
                    break;
                case SqlType.Delete:
                    deleteListEntities.Add(list, new Tuple<IUnitOfWorkRepository, Action<IEnumerable<TEntity>>>(repository, action));
                    break;
                default:
                    throw new ArgumentException("you enter reference is error.");
            }
        }
        #endregion
    }
}
