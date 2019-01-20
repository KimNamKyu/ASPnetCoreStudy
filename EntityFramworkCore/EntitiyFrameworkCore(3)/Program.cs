using EntityFrameworkCore_3_.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntitiyFrameworkCore_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfStudyDbContext())
            {
                var list = db.Users
                    .Include(u=>u.Position) //Include 를 사용하면 조인된 컬럼을 모두 가져오게됨. => Linq 쿼리를 권장하게됨
                    .ToList();

                foreach (var user in list)
                {
                    Console.WriteLine($"{user.UserId}. {user.UserName}({user.Birth}, {user.Position.PositionName})");
                }
            }
        }
    }
}
