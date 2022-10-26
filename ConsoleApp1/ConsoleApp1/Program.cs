using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var mBox = new MessageBox();

            mBox.MyEvent += state =>
            {
                if (state == State.Cancel)
                {
                    Console.WriteLine("операція була відхилена");
                }

                if (state == State.Ok)
                {
                    Console.WriteLine("операція була підтверджена");
                }
            };

            var tcs = new TaskCompletionSource();

            mBox.MyEvent += x => tcs.SetResult();
            mBox.Open();

            await tcs.Task;
        }
    }
}
