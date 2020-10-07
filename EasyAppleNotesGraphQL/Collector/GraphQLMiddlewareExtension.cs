using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyAppleNotesGraphQL.Collector
{
    public static class GraphQLMiddlewareExtension
    {
       public static void UseGraphQL<TSchema>(this IApplicationBuilder builder)
            where TSchema : ISchema
       {
            builder.UseMiddleware<GraphQLMiddleWare<TSchema>>();
            builder.UseGraphiQl();
       }
    }

    public class GraphQLMiddleWare<TSchema> where TSchema: ISchema
    {
        private readonly TSchema _schema;
        private readonly IDocumentWriter _writer;
        private readonly IDocumentExecuter _executer;
        private readonly RequestDelegate _next;

        public GraphQLMiddleWare(
            RequestDelegate next,
            TSchema schema,
            IDocumentWriter writer,
            IDocumentExecuter executer
        )
        {
            _next = next;
            _schema = schema;
            _writer = writer;
            _executer = executer;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Method.ToLower().Equals("post") || !context.Request.Path.ToString().Equals("/graphql"))
            {
                await _next(context);
                return;
            }

            var requestBody = Deserialize<GraphQLRequest>(context.Request.Body);
            var result = await _executer.ExecuteAsync(new ExecutionOptions()
            {
                Schema = _schema,
                Query = requestBody.Query,
                OperationName = requestBody.OperationName,
                Inputs = requestBody.Variables.ToInputs()
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.Errors.Any() ? int.Parse(result.Errors.First()?.Code) : (int)HttpStatusCode.OK;
            await context.Response.WriteAsync(await _writer.WriteToStringAsync(result));
        }

        private T Deserialize<T>(Stream body)
        {
            using var reader = new StreamReader(body);
            using var jsonreader = new JsonTextReader(reader);
            return new JsonSerializer().Deserialize<T>(jsonreader);
        }
    }

    public class GraphQLRequest
    {
        private JObject _variables;
        public string OperationName { get; set; }
        public string Query { get; set; }

        public JObject Variables
        {
            get => _variables ?? new JObject(new { });
            set => _variables = value;
        }

    }
}
