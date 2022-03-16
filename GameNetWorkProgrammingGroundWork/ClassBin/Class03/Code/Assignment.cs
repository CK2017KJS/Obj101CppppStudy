using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MyBasedSocket;

/*

Thread Programming GroundWork 연습하기
    - Join 사용 연습
    - Thread 에서의 인자 전달 방법
    - Thread 에서의 Moniter 또는 Lock 연습
    - C#기반의 Thread 서버/ C#기반의 Tcp Client(Thread아님)
    - C#기반의 UDP Thread 서버/C# 기반의 UDP Client
    


*/

namespace MyTcp
{
    namespace Client
    {
        public class WithClass: MyBasedSocket.TCP.Client
        {
            public void Run()
            {
                string input;
                
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "exit")
                        break;

                    Write(input);
                    Read();
                    Console.WriteLine(Encoding.ASCII.GetString(data,0,recv));

                }
                Close();

            }
        }
    }


    namespace Sever{
    public class WithThread:MyBasedSocket.TCP.Sever
    {

            void Run()
            {
                while(true)
                {
                    while(!client.Pending())
                    {
                        Thread.Sleep(1000);
                    }    
                }

                MyBasedSocket.TCP.ThreadConnect newConnect = new MyBasedSocket.TCP.ThreadConnect();
                newConnect.Init(this.client);

                Thread newThrad = new Thread(new ThreadStart(newConnect.Run));
                newThrad.Start();
            }
        }
    }

}

namespace MyUdp
{


}