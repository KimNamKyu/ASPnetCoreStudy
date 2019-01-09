using EntityFrameworkCore_2_.Data;
using EntityFrameworkCore_2_.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfStudyDbContext())
            {
                // 1. SELECT 쿼리 DbSet을 잘 사용하진 않음
                // 1) DbSet<User> selectList = db.Users;

                // 메서드 체인형식으로 .().()
                //  Linq 는 기존 DB SQL쿼리를 직접 날려야 하지만 C#코드로 쿼리를 날려줄수 있는 기능 
                // 2) List<User> selectList = db.Users.ToList().where().Order();
                // 3) IEnumerable<User> selectList = db.Users.AsEnumerable(); //열거형태처럼

                // Linq to Sql 로 Sql문을 C#코드에서 작성하여 사용의 편의성을 높임 한국에서는 별로 없다네
                // var selectList = from user in db.Users select user;  // Linq to Sql
                
            }
        }
    }
}
