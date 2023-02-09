namespace GraphQL.GraphQLToConfig;
using GraphQL;
class Program
{
    static void Main(string[] args)
    {
        File file = new File("schema.graphql");
        var str = file.ReadFile();
        GraphQL graphQL = new GraphQL(str);
        graphQL.GetTypesString();
        
    }
}

