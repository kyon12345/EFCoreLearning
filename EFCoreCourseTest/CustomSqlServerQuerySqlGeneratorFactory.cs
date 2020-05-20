using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Microsoft.EntityFrameworkCore.SqlServer.Query.Internal
{
    public class CustomSqlServerQuerySqlGeneratorFactory : SqlServerQuerySqlGeneratorFactory
    {
        private readonly QuerySqlGeneratorDependencies _dependencies;
        public CustomSqlServerQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies)
            : base(dependencies)
        {
            _dependencies = dependencies;
        }
        public override QuerySqlGenerator Create() =>
           new CustomSqlServerQuerySqlGenerator(_dependencies);
    }

    public class CustomSqlServerQuerySqlGenerator : SqlServerQuerySqlGenerator
    {
        public CustomSqlServerQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
            : base(dependencies) { }
        protected override Expression VisitTable(TableExpression tableExpression)
        {
            var result = base.VisitTable(tableExpression);
            Sql.Append(" WITH (NOLOCK)");
            return result;
        }
    }
}