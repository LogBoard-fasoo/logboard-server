#pragma warning disable CS1591
using Renci.SshNet;
using System;

namespace LogBoard.Models
{
    public class SshTunnelService : IDisposable
    {
        private SshClient client;
        private ForwardedPortLocal portFwdL;

        public SshTunnelService(string sshHostName, string sshUserName, string sshPassword, int sshPort, string databaseHost, int localPort)
        {
            // SSH 터널 생성
            var connectionInfo = new ConnectionInfo(sshHostName, sshPort, sshUserName, new PasswordAuthenticationMethod(sshUserName, sshPassword));
            client = new SshClient(connectionInfo);
            client.Connect();
            if (client.IsConnected)
            {
                portFwdL = new ForwardedPortLocal("127.0.0.1", (uint)localPort, databaseHost, (uint)localPort);
                client.AddForwardedPort(portFwdL);
                portFwdL.Start();
            }
        }

        public void Dispose()
        {
            portFwdL?.Stop();
            client?.Disconnect();
        }
    }
}
