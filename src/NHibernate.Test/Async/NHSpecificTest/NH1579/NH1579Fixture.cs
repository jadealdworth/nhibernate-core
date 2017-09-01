﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH1579
{
	using System.Threading.Tasks;
	[TestFixture]
	public class NH1579FixtureAsync : BugTestCase
	{
		[Test]
		public async Task TestAsync()
		{
			Cart cart = new Cart("Fred");
			Apple apple = new Apple(cart);
			Orange orange = new Orange(cart);
			cart.Apples.Add(apple);
			cart.Oranges.Add(orange);

			using (ISession session = OpenSession())
			{
				using (ITransaction tx = session.BeginTransaction())
				{
					await (session.SaveAsync(cart));
					await (tx.CommitAsync());
				}
			}

			using (ISession session = OpenSession())
			{
				IQuery query = session.CreateQuery("FROM Fruit f WHERE f.Container.id = :containerID");
				query.SetGuid("containerID", cart.ID);
				IList<Fruit> fruit = await (query.ListAsync<Fruit>());
				Assert.AreEqual(2, fruit.Count);
			}

			using (ISession session = OpenSession())
			{
				using (ITransaction tx = session.BeginTransaction())
				{
					await (session.DeleteAsync("FROM Entity"));
					await (tx.CommitAsync());
				}
			}
		}
	}
}
