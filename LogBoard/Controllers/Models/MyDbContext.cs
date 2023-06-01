using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogBoard.Controllers.Models
{
    public class MyDbContext : DbContext {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions option) : base(option)
        {  // 생성자 함수             
        }
        public DbSet<Ip> Ip { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<VisitedUrl> VisitedUrl { get; set; }
        public DbSet<UrlCategory> UrlCategory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("DefaultConnection"); // 연결 문자열
        }
    }
}
