﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using NHibernate.DomainModel;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH3795
{
	using System.Threading.Tasks;
	/// <summary>
	/// Tests in this class only failed when the code was build with the Roslyn compiler which is included in Visual Studio 2015
	/// </summary>
	[TestFixture]
	public class FixtureAsync : TestCase
	{
		protected Child ChildAliasField = null;
		protected A AAliasField = null;

		protected override IList Mappings
		{
			get { return new[] {"ParentChild.hbm.xml", "ABC.hbm.xml"}; }
		}

		[Test]
		public async Task TestFieldAliasInQueryOverAsync()
		{
			using (var s = Sfi.OpenSession())
			{
				A rowalias = null;
				await (s.QueryOver(() => AAliasField)
				 .SelectList(
					 list => list
						 .Select(() => AAliasField.Id).WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestFieldAliasInQueryOverWithConversionAsync()
		{
			using (var s = Sfi.OpenSession())
			{
				B rowalias = null;
				await (s.QueryOver(() => AAliasField)
				 .SelectList(
					 list => list
						 .Select(() => ((B) AAliasField).Count).WithAlias(() => rowalias.Count))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestFieldAliasInJoinAliasAsync()
		{
			using (var s = Sfi.OpenSession())
			{
				Child rowalias = null;
				await (s.QueryOver<Parent>()
				 .JoinAlias(p => p.Child, () => ChildAliasField)
				 .SelectList(
					 list => list
						 .Select(() => ChildAliasField.Id).WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestFieldAliasInJoinQueryOverAsync()
		{
			using (var s = Sfi.OpenSession())
			{
				Child rowalias = null;
				await (s.QueryOver<Parent>()
				 .JoinQueryOver(p => p.Child, () => ChildAliasField)
				 .SelectList(
					 list => list
						 .Select(() => ChildAliasField.Id).WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestAliasInQueryOverAsync()
		{
			A aAlias = null;
			using (var s = Sfi.OpenSession())
			{
				A rowalias = null;
				await (s.QueryOver(() => aAlias)
				 .SelectList(
					 list => list
						 .Select(() => aAlias.Id)
						 .WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestAliasInQueryOverWithConversionAsync()
		{
			A aAlias = null;
			using (var s = Sfi.OpenSession())
			{
				B rowalias = null;
				await (s.QueryOver(() => aAlias)
				 .SelectList(
					 list => list.Select(() => ((B) aAlias).Count)
								 .WithAlias(() => rowalias.Count))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestAliasInJoinAliasAsync()
		{
			Child childAlias = null;

			using (var s = Sfi.OpenSession())
			{
				Child rowalias = null;
				await (s.QueryOver<Parent>()
				 .JoinAlias(p => p.Child, () => childAlias)
				 .SelectList(
					 list => list.Select(() => childAlias.Id)
								 .WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}

		[Test]
		public async Task TestAliasInJoinQueryOverAsync()
		{
			Child childAlias = null;

			using (var s = Sfi.OpenSession())
			{
				Child rowalias = null;
				await (s.QueryOver<Parent>()
				 .JoinQueryOver(p => p.Child, () => childAlias)
				 .SelectList(
					 list => list.Select(() => childAlias.Id)
								 .WithAlias(() => rowalias.Id))
				 .ListAsync());
			}
		}
	}
}
