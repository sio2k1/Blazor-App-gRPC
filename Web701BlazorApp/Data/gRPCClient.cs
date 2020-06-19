using Google.Protobuf.Collections;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB701GRPC.Protos;
using static WEB701GRPC.Protos.Web701;

namespace Web701BlazorApp.Data
{
    public class gRPCClient //we use this to connect to gRPC back-end
    {
        public static string backEndAddress = "http://localhost:5001";
        public static async Task<List<Article>> GetArticleList()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress(backEndAddress);
            var client = new Web701Client(channel);
            ArticleListReply res = await client.GetArticleListAsync(new GetArticleListRequest());
            if (res.ErrorMsg != "")
               throw new Exception(res.ErrorMsg);
            return res.Articles.ToList();
        }
    }
}
