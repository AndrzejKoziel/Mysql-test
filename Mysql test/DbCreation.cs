using ServiceStack.OrmLite;

namespace Mysql_test
{
    public static class DbCreation
    {
        public class LowercaseNamingStrategy : OrmLiteNamingStrategyBase
        {
            public override string GetTableName(string name)
            {
                return name.ToLower();
            }
        }

        static DbCreation()
        {
            OrmLiteConfig.CommandTimeout = 90;
        }

        public static OrmLiteConnectionFactory Create(string connectionStringName)
        {
            string connectionString = connectionStringName;
            return new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider)
            {
                DialectProvider =
                {
                    NamingStrategy = new LowercaseNamingStrategy()
                }
            };
        }

        public static OrmLiteConnectionFactory CreateCustomConnection(string connectionString)
        {
            return new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider)
            {
                DialectProvider =
                {
                    NamingStrategy = new LowercaseNamingStrategy()
                }
            };
        }
    }
}