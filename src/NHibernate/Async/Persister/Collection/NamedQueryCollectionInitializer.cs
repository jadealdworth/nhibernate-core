﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



using NHibernate.Engine;
using NHibernate.Impl;
using NHibernate.Loader.Collection;

namespace NHibernate.Persister.Collection
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial class NamedQueryCollectionInitializer : ICollectionInitializer
	{

		public Task InitializeAsync(object key, ISessionImplementor session, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				if (log.IsDebugEnabled)
				{
					log.Debug(string.Format("initializing collection: {0} using named query: {1}", persister.Role, queryName));
				}

				//TODO: is there a more elegant way than downcasting?
				AbstractQueryImpl query = (AbstractQueryImpl) session.GetNamedSQLQuery(queryName);
				if (query.NamedParameters.Length > 0)
				{
					query.SetParameter(query.NamedParameters[0], key, persister.KeyType);
				}
				else
				{
					query.SetParameter(0, key, persister.KeyType);
				}
				return query.SetCollectionKey(key).SetFlushMode(FlushMode.Manual).ListAsync(cancellationToken);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}
	}
}