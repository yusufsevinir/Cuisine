// Type: System.Data.Entity.DbContext
// Assembly: EntityFramework, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Users\neccar\Cuisine\Cuisine\Cuisine\packages\EntityFramework.4.1.10331.0\lib\EntityFramework.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Objects;

namespace System.Data.Entity
{
    public class DbContext : IDisposable, IObjectContextAdapter
    {
        protected DbContext();
        protected DbContext(DbCompiledModel model);
        public DbContext(string nameOrConnectionString);
        public DbContext(string nameOrConnectionString, DbCompiledModel model);
        public DbContext(DbConnection existingConnection, bool contextOwnsConnection);
        public DbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection);
        public DbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext);
        public Database Database { get; }
        public DbChangeTracker ChangeTracker { get; }
        public DbContextConfiguration Configuration { get; }

        #region IDisposable Members

        public void Dispose();

        #endregion

        #region IObjectContextAdapter Members

        ObjectContext IObjectContextAdapter.ObjectContext { get; }

        #endregion

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder);
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet Set(Type entityType);
        public virtual int SaveChanges();
        public IEnumerable<DbEntityValidationResult> GetValidationErrors();
        protected virtual bool ShouldValidateEntity(DbEntityEntry entityEntry);
        protected virtual DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        public DbEntityEntry Entry(object entity);
        protected virtual void Dispose(bool disposing);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType();
    }
}
