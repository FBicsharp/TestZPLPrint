using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestZPLPrint
{
    internal class SocketManager
    {
        private int _port;
        private string _ip { get; set; }
        private Socket _socket;

        public SocketManager ForIP(string ip)
        {
            _ip = ip;
            return this;
        }

        public SocketManager WithPort(int port)
        {
            _port = port;
            return this;
        }

        public NetworkStream OpenSocket()
        {
                   
            var Ip = IPAddress.Parse(_ip);            
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _socket.Connect(Ip, _port);
            }
            catch (Exception)
            {
                return null;

            }
            
            if (!_socket.Connected)
            {
                return null;
            }
            var networkStream = new NetworkStream(_socket);            
            return networkStream;
        }
        public void CloseSocket()
        {
            _socket.Close();            
        }


        public bool SendStream(string content)
        {
            var networkStream = OpenSocket();
            if (networkStream==null) return false;

            byte[] dati = Encoding.Default.GetBytes(content);
            networkStream.Write(dati, 0, dati.Length);
            networkStream.Flush();            
            networkStream.Close();
            CloseSocket();
            return true;
            
        }


    }
}
