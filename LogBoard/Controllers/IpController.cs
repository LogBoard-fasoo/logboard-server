using System.Collections.Generic;
using System.Data;
using System.Linq;

using LogBoard.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Newtonsoft.Json;
using Renci.SshNet;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
  
        // GET: api/<IpController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using var context = new MyDbContext();
            var ips = context.Ip.ToList();

            return (IEnumerable<string>)ips;
            // return new string[] { "value1", "value2" };
        }

        // GET api/<IpController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            using (var sshClient = new SshClient("<<ssh host>>", "<<ssh port>>", "<<ssh username>>", "<<ssh password>>"))
            {
                sshClient.Connect();
                ForwardedPortLocal tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306); // tunnel Job
                sshClient.AddForwardedPort(tunnel);
                tunnel.Start();
                MySqlConnection mycon = new MySqlConnection("Server=127.0.0.1;Database=<<ssh db name>>;Uid=<<ssh username>>;Pwd=<<ssh password>>;SslMode=none;Port=3306;");
                mycon.Open(); // MySQL Job
                MySqlCommand mycmd = new MySqlCommand("<<쿼리문>>");
                MySqlDataAdapter da = new MySqlDataAdapter();
                mycmd.Connection = mycon;
                da.SelectCommand = mycmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                string JSONstring = JsonConvert.SerializeObject(dt);
            }
            return "value";
        }

        // POST api/<IpController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
