using evercloud.Domain.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace evercloud.Service.Services
{
    public class DomainService : IDomainService
    {
        public async Task<bool> IsDomainAvailableAsync(string domain)
        {
            try
            {
                using var client = new TcpClient();
                await client.ConnectAsync("whois.verisign-grs.com", 43);

                using var stream = client.GetStream();
                var query = Encoding.ASCII.GetBytes(domain + "\r\n");
                await stream.WriteAsync(query);

                using var reader = new StreamReader(stream, Encoding.ASCII);
                var response = await reader.ReadToEndAsync();

                return response.Contains("No match for");
            }
            catch
            {
                return false;
            }
        }
    }
}
