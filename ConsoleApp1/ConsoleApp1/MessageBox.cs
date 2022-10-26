using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MessageBox
    {
        public event Action<State> MyEvent;
        public State GetRandState
        {
            get
            {
                switch (new Random().Next(1, 3))
                {
                    case 1:
                        return State.Cancel;
                    case 2:
                        return State.Ok;
                    default:
                        return State.Error;
                }
            }
        }

        public async void Open()
        {
            Console.WriteLine("The window is open");
            await Task.Delay(3000);
            Console.WriteLine("The window is closed");
            MyEvent.Invoke(GetRandState);
        }
    }
}
