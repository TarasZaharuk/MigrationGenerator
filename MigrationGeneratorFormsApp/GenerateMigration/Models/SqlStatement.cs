namespace GenerateMigration.Models
{
    public class SqlStatement
    {
        public SqlStatement(string code, QueryType queryType)
        {
            Code = code;
            QueryType = queryType;
        }
        public string Code { get; set; }
        public QueryType QueryType { get; set; }
    }
}
