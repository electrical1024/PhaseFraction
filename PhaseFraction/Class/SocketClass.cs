using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PhaseFraction
{
    public class SocketClass
    {
        public static Alarmshow MessageofSocketClass = null;   //報警(寫在ggevent函數內)
        // 创建一个和客户端通信的套接字
        public Socket SocketWatch = null;
        //定义一个集合，存储客户端信息
        public Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };

        public bool SocketServerStart(string localIP, int localPort)
        {
            try
            {
                //定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）  
                SocketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //服务端发送信息需要一个IP地址和端口号  
                IPAddress address = IPAddress.Parse(localIP);

                //将IP地址和端口号绑定到网络节点point上  
                IPEndPoint point = new IPEndPoint(address, localPort);

                //此端口专门用来监听的  

                //监听绑定的网络节点  
                SocketWatch.Bind(point);

                //将套接字的监听队列长度限制为20  
                SocketWatch.Listen(20);

                //负责监听客户端的线程:创建一个监听线程  
                Thread threadwatch = new Thread(WatchConnecting);

                //将窗体线程设置为与后台同步，随着主线程结束而结束  
                threadwatch.IsBackground = true;

                //启动线程     

                threadwatch.Start();

                MessageofSocketClass("開啟TCP服務器成功！IP：" + localIP + "，Port：" + localPort, LogType.FlowLog, false);
                return true;
            }
            catch (Exception ex)
            {
                MessageofSocketClass("開啟TCP服務器失敗！IP：" + localIP + "，Port：" + localPort + ex.Message, LogType.FlowLog, false);
                return false;

            }
        }

        //监听客户端发来的请求  
        public void WatchConnecting()
        {
            Socket connection = null;
        
            try
            {
                //持续不断监听客户端发来的请求     
                while (true)
                {
                    try
                    {
                        connection = SocketWatch.Accept();
                    }
                    catch (Exception ex)
                    {
                        //提示套接字监听异常   
                        MessageofSocketClass(ex.Message, LogType.FlowLog, false);
                        break;
                    }

                    //获取客户端的IP和端口号  
                    IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                    int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                    //让客户显示"连接成功的"的信息  
                    //string sendmsg = "連接服務端成功！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
                    //byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                    //connection.Send(arrSendMsg);

                    //客户端网络结点号  
                    string remoteEndPoint = connection.RemoteEndPoint.ToString();
                    //显示与客户端连接情况
                   
                    MessageofSocketClass("成功与" + remoteEndPoint + "客戶端建立連接！！", LogType.FlowLog, false);
                    //添加客户端信息  
                    //clientConnectionItems.Add(remoteEndPoint, connection);

                    //IPEndPoint netpoint = new IPEndPoint(clientIP,clientPort); 
                    IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                    //创建一个通信线程      
                    ParameterizedThreadStart pts = new ParameterizedThreadStart(ReceiveSocketClient);
                    Thread thread = new Thread(pts);
                    //设置为后台线程，随着主线程退出而退出 
                    thread.IsBackground = true;
                    //启动线程     
                    thread.Start(connection);
                }

            }
            catch (Exception ex)
            {
                   
                MessageofSocketClass(ex.Message+connection.RemoteEndPoint.ToString(), LogType.FlowLog, false);
            }
        }
        /// <summary>
        /// 接收客户端发来的信息，客户端套接字对象
        /// </summary>
        /// <param name="socketClientPara"></param>
        public void ReceiveSocketClient(object socketClientPara)
        {
            Socket socketClient = socketClientPara as Socket;
            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节  即1M     
                byte[] serverRecMsg = new byte[1024 * 1024];
             
                bool uploadState = false;
                //将接收到的信息存入到内存缓冲区，并返回其字节数组的长度    
                try
                {
                    int length = socketClient.Receive(serverRecMsg);
                    if (length == 0) { break; }

                    string receiveMsg = Encoding.UTF8.GetString(serverRecMsg, 0, length);
                    receiveMsg = receiveMsg.Replace("\0", "");
                    receiveMsg = receiveMsg.Replace("\b", "");
                    receiveMsg = receiveMsg.Replace("\n", "");
                    receiveMsg = receiveMsg.Replace("\r", "");
                    receiveMsg = receiveMsg.Trim();
                    if (length > 10 && receiveMsg != "1")
                    {
                        MessageofSocketClass("接收客戶端" + socketClient.RemoteEndPoint + "：" + receiveMsg, LogType.FlowLog, false);
                      
                    }
                   

                }
                catch (Exception ex)
                {
                  // clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());

                   // Console.WriteLine("Client Count:" + clientConnectionItems.Count);

                    //提示套接字监听异常 
                    MessageofSocketClass("客戶端" + socketClient.RemoteEndPoint + "已經中斷連接," + ex.Message + ex.StackTrace, LogType.FlowLog, false);
                    //关闭之前accept出来的和客户端进行通信的套接字 
                    socketClient.Close();
                    break;
                }
            }
        }

        public void SocketSend(Socket connection, string sendMsg)
        {
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            connection.Send(arrSendMsg);
        }

        ///      
        /// 获取当前系统时间的方法    
        /// 当前时间     
        public DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(SendMsg);
            t.IsBackground = true;
            t.Start("send test");

        }

        private void SendMsg(object obj)
        {
            int portSend = 5050;
            string message = (string)obj;
            UdpClient SendClient = new UdpClient(0);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);
            IPAddress remoteIp = IPAddress.Parse("192.168.1.1");
            IPEndPoint iep = new IPEndPoint(remoteIp, portSend);
            try
            {
                SendClient.Send(bytes, bytes.Length, iep);
                MessageBox.Show(string.Format("向{0}发送：{1}", iep, message));  //异步委托显示数据

            }
            catch (Exception ex)
            {
                MessageBox.Show("发送出错" + ex.Message);
            }
        }



        private void FormChat_Load(object sender, EventArgs e)
        {
            //创建接收线程
            Thread RecivceThread = new Thread(RecivceMsg);
            RecivceThread.IsBackground = true;
            RecivceThread.Start();

        }

        private void RecivceMsg()
        {
            int portRecv = 5050;
            int portSend = 5050;
            IPAddress localIp = IPAddress.Parse("192.168.1.1");
            IPEndPoint local = new IPEndPoint(localIp, portRecv);
            UdpClient RecviceClient = new UdpClient(local);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, portSend);
            while (true)
            {
                try
                {
                    byte[] recivcedata = RecviceClient.Receive(ref remote);
                    string strMsg = Encoding.ASCII.GetString(recivcedata, 0, recivcedata.Length);
                    MessageBox.Show(string.Format("来自{0}：{1}", remote, strMsg));
                }
                catch
                {
                    break;
                }
            }
        }

    }


}
