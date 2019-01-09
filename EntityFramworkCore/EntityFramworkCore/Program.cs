using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entity Framework 는 Db Context가 가장 중요해
            //using 사용하면 특정 리소스 접근해서 생성햇고 using 안에 리소스 자동으로 닫는다.
            using (var db = new EfStudyDbContext())
            {
                var userList = db.Users;

                //List 이기 때문에 foreach
                foreach (var user in userList)
                {
                    Console.WriteLine(user.UserName);
                    Console.WriteLine(user.Birth);
                }
            }
        }
    }

    public class EfStudyDbContext : DbContext
    {
        //테이블 정의
        public DbSet<User> Users { get; set; }

        //로컬 DB연동 커넥션 스트링 설정하기
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    /// <summary>
    ///  모델 클래스
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Birth { get; set; }
    }
}
