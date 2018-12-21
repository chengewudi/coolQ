using MyEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDB") { }

        public DbSet<Idols> Idols { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Period> Periods { get; set; }

        public DbSet<QQGroup> QQGroups { get; set; }

        public DbSet<QQGroupHistoryMsg> QQGroupHistoryMsgs { get; set; }
    }
}
