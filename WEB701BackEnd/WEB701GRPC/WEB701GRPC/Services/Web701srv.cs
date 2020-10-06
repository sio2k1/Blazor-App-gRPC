using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using WEB701GRPC.Protos;

namespace WEB701GRPC
{
    public class Web701Service : Web701.Web701Base
    {
        private readonly ILogger<Web701Service> _logger;
        public Web701Service(ILogger<Web701Service> logger)
        {
            _logger = logger;
        }
        public override Task<ArticleListReply> GetArticleList(GetArticleListRequest request, ServerCallContext context)
        {
            string text = @"

            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam finibus eget enim vitae gravida. Aenean sit amet velit ligula. Proin non purus eu diam rhoncus mattis lacinia id felis. Phasellus quis tincidunt justo, non tincidunt nisl. Nunc rutrum ante risus, in rhoncus tortor cursus a. Ut egestas, leo a euismod accumsan, purus ipsum tristique enim, ac tristique lacus est vitae dolor. In non sem diam. Etiam imperdiet eleifend enim, eleifend sollicitudin metus posuere eu. Aenean in commodo nunc. Integer diam quam, aliquam sed dolor quis, eleifend semper tortor.

            Ut malesuada turpis turpis, quis luctus nibh consequat id. Mauris lacinia orci non ligula porttitor egestas. Vestibulum sit amet tristique augue. Pellentesque sit amet neque ac lectus volutpat laoreet. Mauris eleifend lobortis nulla nec tempor. Nunc eget aliquam neque. Nam nec venenatis dui. Fusce at metus consequat, varius nisi eu, vestibulum nisl. Integer id venenatis turpis, nec tincidunt quam. Nunc mollis nisi leo, a pellentesque elit pretium id. Morbi in viverra tellus.

            Aliquam odio orci, mollis in odio sit amet, accumsan lobortis quam. Aliquam egestas neque pretium felis mattis, id efficitur tortor semper. Donec interdum aliquam vestibulum. Cras dignissim sagittis massa vitae malesuada. Proin sit amet arcu eu ante euismod eleifend. Maecenas gravida lorem at mi molestie mollis. Mauris id orci scelerisque, volutpat risus rhoncus, eleifend diam. Ut aliquet neque risus. Nunc lorem erat, finibus vel tortor vitae, fermentum tempor sem. Vivamus in maximus tortor. Aliquam in lacus eu lorem efficitur lacinia. Duis nec lectus vel magna ornare ullamcorper sed quis erat.

            Cras venenatis vehicula metus eget ornare. Quisque ut nisi eu dui mollis euismod at vel quam. Nam a laoreet velit. Aliquam vitae odio nulla. Sed augue lorem, bibendum nec nunc id, maximus pellentesque justo. Donec sapien dolor, mattis ut luctus non, lacinia at purus. Quisque at commodo erat. Sed finibus erat elit, luctus luctus odio sodales ut. Curabitur sodales diam non ligula congue, vel lobortis nisi mattis. Donec tempus in sapien at pharetra. Fusce lobortis purus lacus, quis malesuada elit scelerisque sit amet. Quisque interdum eros et tempor faucibus. Curabitur ultrices auctor sem, eget porttitor dui fringilla id. Mauris cursus at purus eget bibendum. Quisque posuere, enim ac egestas egestas, neque ligula interdum turpis, at vehicula velit metus nec augue.

            Aenean nunc diam, sagittis id tempus nec, mattis ut metus. Mauris finibus mauris urna, a euismod ligula accumsan sed. Aliquam et leo id turpis feugiat lobortis at quis neque. Maecenas ipsum felis, rutrum non ornare ultricies, elementum sed sapien. Suspendisse in odio venenatis orci congue molestie et vel quam. Sed quis elit in ante dictum ornare eget eu mi. Integer eleifend lobortis pharetra. Fusce non felis erat. Sed molestie lectus arcu, nec posuere massa hendrerit a. Vivamus congue dui a suscipit sodales.

            Nulla viverra metus in quam congue, sed vestibulum erat accumsan. Donec egestas nulla et nunc luctus, a euismod nisi efficitur. Suspendisse potenti. Quisque vitae pellentesque ipsum, a placerat augue. Sed id fermentum nisl. Pellentesque eu nunc nec lacus porta pellentesque. Aenean a nulla non ligula fringilla accumsan id. ";





            var response = new ArticleListReply();
            int id = 1;
            response.Articles.Add(new Article { Id = id++, Title = "Nam finibus eget", Text = text, ImageLink= $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Aenean sit amet", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Aliquam egestas", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Mauris finibus", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Aliquam vitae", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = " Donec egestas", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Suspendisse", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Nam a laoreet", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            response.Articles.Add(new Article { Id = id++, Title = "Donec interdum", Text = text, ImageLink = $"https://picsum.photos/200/200?random={id}>" });
            return Task.FromResult(response);
        }


    }
}
