using System.Collections.Generic;
using System.Linq;
using Cards.Models;
using EdjCase.JsonRpc.Router;
using log4net;

namespace Cards.Controllers
{
    public class TestController : RpcController
    {
        private readonly TestContext context;
        private readonly ILog log;

        public TestController(TestContext context, ILog log)
        {
            this.context = context;
            this.log = log;
        }

        public List<Blog> List()
        {
            log.Debug($"total count: {context.Blogs.Count()}");
            return context.Blogs.ToList();
        }

        public Blog Get(int id)
        {
            return context.Blogs.First(x => x.BlogId == id);
        }

        //POST /Test
        //Example request using param list: {"jsonrpc": "2.0", "id": 1, "method": "Add", "params": [1,2]}
        //Example request using param map: {"jsonrpc": "2.0", "id": 1, "method": "Add", "params": {"a": 1, "b": 2}}
        public void Add(int id, string url)
        {
            var blog = new Blog
            {
                BlogId = id,
                Url = url
            };
            context.Blogs.Add(blog);
            context.SaveChanges();
        }
    }
}