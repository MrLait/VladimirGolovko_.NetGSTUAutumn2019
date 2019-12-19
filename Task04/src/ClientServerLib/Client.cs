using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
//у если надо перестраховаться то, цикл do{...}while(available) нужно обернуть в stream.CanRead,а что-бы отслежитвать отвалился 
//    ли клиент - юзаем if (!client.Connected) { ... } Ну и таймаут на чтение можно выставить у стрима, что-бы не было бесконечных 
//    циклов в случаи форс-мажорных обстоятельств

namespace ConsoleAppTcpClient
{
    public class Client
    {
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private string _name;

        public Client(string name)
        {
            _name = name;
        }

        public void LoadClient()
        {
            string userName = _name;
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write(userName + ": ");
                    // ввод сообщения
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);
                    // преобразуем сообщение в массив байтов
                    byte[] dataWrite = Encoding.Unicode.GetBytes(message);
                    // отправка сообщения
                    stream.Write(dataWrite, 0, dataWrite.Length);

                    byte[] dataRead = new byte[256];
                    StringBuilder response = new StringBuilder();
                    // получаем сетевой поток для чтения и записи
                    //if (stream.DataAvailable)
                    //{
                        do
                        {
                            int bytes = stream.Read(dataRead, 0, dataRead.Length);
                            response.Append(Encoding.Unicode.GetString(dataRead, 0, bytes));
                        }
                        while (stream.DataAvailable) ; // пока данные есть в потоке

                        Console.WriteLine(response.ToString());
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                Console.WriteLine("client stop");
                client.Close();
            }
        }
    }
}
