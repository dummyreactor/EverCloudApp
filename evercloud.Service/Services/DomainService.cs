using evercloud.Service.Interfaces;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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
                await stream.WriteAsync(query, 0, query.Length);

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
