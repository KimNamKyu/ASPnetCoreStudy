﻿
using EntitiyFrameworkCore_3_.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_3_.Data
{
    public class EfStudyDbContext : DbContext
    {
        //테이블 정의
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }

        //로컬 DB연동 커넥션 스트링 설정하기
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=AspnetCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
