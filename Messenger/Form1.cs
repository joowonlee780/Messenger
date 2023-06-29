using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Messenger
{
    public partial class Messenger : Form
    {

        //연결되었는지 확인하는 변수
        bool isConnect;

        //클라이언트용 소켓
        Socket clientSocket;

        //서버용 소켓
        Socket listenSocket;
        Socket serverSocket;


        //받아온 데이터 저장용
        string data;



        //라디오 버튼 어느쪽인지
        bool isServerRadioCheck;
        bool isClientRadioCheck;
        

        


        public Messenger() //생성자, 멤버 변수 초기화
        {
            InitializeComponent();
            Connected_Box_Visable(false);
            isServerRadioCheck = false;
            isClientRadioCheck = false;
            isConnect = false;
            ipBox.Enabled = false;
            portBox.Enabled = false;
            startButton.Enabled = false;
            connectButton.Enabled = false;
            sendButton.Enabled = false;
        }








        //공용함수

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }


        private void Server_Check(object sender, EventArgs e) //체크가 서버일 때 UI 변수 초기화
        {
            if (isServerRadioCheck) return;

            isServerRadioCheck = true;
            isClientRadioCheck = false;
            startButton.Enabled = true;
            ipBox.Enabled = false;
            portBox.Enabled = true;
            startButton.Visible = true;
            connectButton.Visible = false;
            messageBox.Items.Add("서버 모드");
        }

        private void Client_Check(object sender, EventArgs e) //체크가 클라이언트일 때 UI 변수 초기화
        {
            if (isClientRadioCheck) return;

            isServerRadioCheck = false;
            isClientRadioCheck = true;
            connectButton.Enabled = true;
            connectButton.Visible = true;
            ipBox.Enabled = true;
            portBox.Enabled = true;
            startButton.Visible = false;
            messageBox.Items.Add("클라이언트 모드");
        }

        private void Connected_Box_Visable(bool connected) //서버,클라 시작시 라디오버튼 비활성화
        {
            if (connected)
            {
                isConnect = true;
                connectedBox.Visible = true;
                disconnectedBox.Visible = false;
            }
            else
            {
                isConnect = false;
                connectedBox.Visible = false;
                disconnectedBox.Visible = true;
            }
        }

        private bool Ip_Check() //IP주소 검증
        {
            IPAddress ipTemp;
            bool isIp = IPAddress.TryParse(ipBox.Text, out ipTemp);

            if (!isIp)
            {
                messageBox.Items.Add("IP 오류");
                return false;
            }
            return true;
        }

        private bool Port_Check() //포트번호 검증
        {
            int portTmp;
            int.TryParse(portBox.Text, out portTmp); //int형으로 변환, 변환불가하면 0리턴
            if (portTmp > 65535 || portTmp <= 0) //포트번호 0번은 예약된 포트번호라 사용하지 않음
            {
                messageBox.Items.Add("포트번호 오류, 1~65535까지만");
                return false;
            }
            return true;
        }

        private void Send_Message() //메세지 보내는 함수
        {
            

            if (!isConnect) return;

            byte[] message = Encoding.Default.GetBytes(sendBox.Text);
            
            if (isServerRadioCheck)
            { int sendInt = serverSocket.Send(message); }

            if (isClientRadioCheck)
            { int sendInt = clientSocket.Send(message); }
           
            messageBox.Items.Add("나>> " + sendBox.Text);
            sendBox.Clear();
            sendBox.Text = "";

            

        }

        private void Receive_Message() //메세지 받는 함수
        {
            

            if (isServerRadioCheck)
            {
                while (isConnect)
                {
                    if (serverSocket != null && listenSocket !=null)
                    {
                        byte[] receiveByte = new byte[1024];
                        int receiveInt = serverSocket.Receive(receiveByte);
                        data = Encoding.Default.GetString(receiveByte,0,receiveInt);


                        if (data =="out")
                        {
                            messageBox.Items.Add("상대방이 나갔습니다. 나가기 버튼을 눌러주세요.");
                            serverSocket.Disconnect(true);
                            //listenSocket.Disconnect(true);


                            sendButton.Enabled = false;




                            data = "";
                            return;
                        }


                        messageBox.Items.Add("상대>> " + data);
                        data = "";
                    }
                }
            }
            if (isClientRadioCheck)
            {
                while (isConnect)
                {
                    if (clientSocket != null)
                    {
                        byte[] receiveByte = new byte[1024];
                        int receiveInt = clientSocket.Receive(receiveByte);
                        data = Encoding.Default.GetString(receiveByte,0,receiveInt);


                        if (data == "out")
                        {
                            messageBox.Items.Add("상대방이 나갔습니다. 나가기 버튼을 눌러주세요.");
                            data = "";



                            sendButton.Enabled = false;




                            clientSocket.Disconnect(true);



                            return;
                        }

                        messageBox.Items.Add("상대>> " + data);
                        data = "";
                    }
                }
            }


        }

        private void Send_Button_Click(object sender, EventArgs e) //send 버튼 클릭시 메세지 보내는 함수
        {
            Send_Message();
        }
              
        private void Send_Box_Enter_Press(object sender, KeyEventArgs e) //send 박스에서 enter치면 메세지 보내는 함수
        {
            if (e.KeyCode == Keys.Enter)
                Send_Message();
        }

        private void Port_Box_Enter_Press(object sender, KeyEventArgs e) //port 박스에서 enter치면 서버/클라에서 연결하는 함수
        {
            if (e.KeyCode == Keys.Enter)
            {
                //라디오버튼이 서버일때
                if(isServerRadioCheck)
                {
                    if (isConnect) return;
                    //내 아이피 주소 알아서 받아와서 쓰게하기
                    if (Get_Myip() == "") return;
                    messageBox.Items.Add("My Ipaddress = " + Get_Myip().ToString());

                    //포트는 입력받기
                    if (!Port_Check()) return;
                    messageBox.Items.Add("Port = " + portBox.Text);

                    Server_Start(Get_Myip(), int.Parse(portBox.Text), 1024);
                }
                

                //라디오버튼이 클라일때
                if(isClientRadioCheck)
                {
                    if (e.KeyCode == Keys.Enter)
                        Connect_Server();
                }

            }
        }

        private void Exit_Button_Click(object sender, EventArgs e) //나가기 버튼 클릭시 소켓 disconnect하고 상대방에게 나갔다고 표시하는 함수
        {
            if (!isConnect) return;
            isConnect = false;

            sendButton.Enabled = false;
            byte[] message = Encoding.Default.GetBytes("out");

            if (isClientRadioCheck)
            {                

                try
                {
                    clientSocket.Send(message);
                    Delay(2000);
                    clientSocket.Disconnect(true);
                    
                    
                }
                catch (Exception ex)
                { }

            }



            if (isServerRadioCheck)
            {                

                try
                {
                    serverSocket.Send(message);
                    Delay(2000);
                    serverSocket.Disconnect(true);
                    listenSocket.Disconnect(true);                 
                }
                catch (Exception ex)
                { }

                
            }



        }

        

        private void Close(object sender, FormClosingEventArgs e) //창 닫을 때 소켓 close하는 함수
        {
            if (!isConnect) return;
            isConnect = false;

            byte[] message = Encoding.Default.GetBytes("out");


            if (isClientRadioCheck)
            {
                int sendInt = clientSocket.Send(message);
                Connected_Box_Visable(false);

                try
                {
                    Delay(4000);
                    if (clientSocket != null)
                        //clientSocket.Close();
                        clientSocket.Disconnect(false);
                }
                catch(Exception ex)
                { }
                /*
                 https://www.delftstack.com/ko/howto/csharp/exit-application-in-csharp/
                 */          

            }

            if (isServerRadioCheck)
            {

                int sendInt = serverSocket.Send(message);
                Connected_Box_Visable(false);
                try
                {

                    Delay(4000);

                    if (serverSocket != null)
                        //serverSocket.Close();
                        serverSocket.Disconnect(false);
                    if (listenSocket != null)
                        //listenSocket.Close();
                        listenSocket.Disconnect(false);
                }
                catch (Exception ex)
                { }

                
            }

            Application.Exit();

            Environment.Exit(1);
        }

        private void Radio_Enable(bool enable) //라디오 버튼 활성화/비활성화 하는 함수
        {
            if(enable)
            {
                //활성화
                serverRadioButton.Enabled = true;
                clientRadioButton.Enabled = true;
            }
            else
            {
                //비활성화
                serverRadioButton.Enabled = false;
                clientRadioButton.Enabled = false;

            }
        }


        
        private void Is_Connected()//연결상태 확인하는 스레드
        {
            while(true)
            {
                if (isConnect)                
                    Connected_Box_Visable(true);
                
                else
                    Connected_Box_Visable(false);
            }
        }



        //서버 모드

        private void Server_Click(object sender, EventArgs e) //서버 클릭하면 아이피 주소는 알아서 받아오고 포트번호 입력받아 서버 시작
        {
            if (!isServerRadioCheck)
            {
                messageBox.Items.Add("모드 선택 필요");
                return;
            }

            Thread connected = new Thread(Is_Connected);          
            connected.Start();


            
            if (isConnect) return;
            //내 아이피 주소 알아서 받아와서 쓰게하기
            if (Get_Myip() == "") return;
            messageBox.Items.Add("My IpAddress = " + Get_Myip().ToString());

            //포트는 입력받기
            if (!Port_Check()) return;
            messageBox.Items.Add("Port = " + portBox.Text);
            Radio_Enable(false);
            Server_Start(Get_Myip(), int.Parse(portBox.Text), 1024);
        }
        private void Server_Start(string ip, int port, int backlog) //ip, port 받아와서 서버 시작하는 함수
        {
            /*
                https://learn.microsoft.com/ko-kr/dotnet/api/system.net.sockets.socket.-ctor?view=net-7.0
                Socket(SocketType, ProtocolType)
                tcp 소켓을 이용
             */

            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), port);

            listenSocket.Bind(endpoint);
            listenSocket.Listen(backlog);

            Thread acceptThread = new Thread(Accept_Request);            
            acceptThread.Start();
            

            Connected_Box_Visable(true);


        }

        private void Accept_Request() //클라이언트 소켓으로부터 요청 수신하는 함수
        {
            while (isConnect)
            {

                
                serverSocket = listenSocket.Accept();


                messageBox.Items.Add("서버연결성공");


                sendButton.Enabled = true;



                Thread listenThread = new Thread(Receive_Message);
                listenThread.Start();
                
            }
            
        }

        private string Get_Myip() //자신의 ip주소 받아오는 함수
        {
            var myIp = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in myIp.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }

            return "";

        }



        //클라이언트 모드

        private void Connect_Server() //서버에 연결하는 함수
        {
            if (!isClientRadioCheck)
            {
                messageBox.Items.Add("모드 선택 필요");
                return;
            }

            //이미 연결되어있으면 실행X
            if (isConnect) return;


            Thread connected = new Thread(Is_Connected);
            connected.Start();

            //포트번호, IP주소 검증
            //둘 중 하나라도 아니면 리턴
            if (!Ip_Check() || !Port_Check()) return;


            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try //연결시도
            {
                clientSocket.Connect(IPAddress.Parse(ipBox.Text), int.Parse(portBox.Text));
            }
            catch (Exception ex) //연결실패
            {
                messageBox.Items.Add($"연결실패: {ex.Message}");
                return;

            }



            //연결성공
            messageBox.Items.Add("서버접속완료 " + IPAddress.Parse(ipBox.Text) + ":" + portBox.Text);

            sendButton.Enabled = true;

            isConnect = true;
            Connected_Box_Visable(true);

            Radio_Enable(false);

            Thread listenThread = new Thread(Receive_Message);
            listenThread.Start();


            

        }

        private void Connect_Button_Click(object sender, EventArgs e) //connect 버튼 누르면 서버에 연결하는 함수
        {
            Connect_Server();
        }

        private void Ip_Box_Enter_Press(object sender, KeyEventArgs e) //ip 박스에서 Enter 치면 서버에 연결하는 함수
        {
            if (e.KeyCode == Keys.Enter)
                Connect_Server();
        }

        
    }
}
