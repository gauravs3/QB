using QuickBookApi.Helpers;
using System;
using System.Threading.Tasks;

namespace QuickBookAPIIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(async () => await CustomHttpHelper.GetAccessToken());
            var bbb = task.Result;
            var aa = CustomHttpHelper.GetAccessToken().ConfigureAwait(false);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}