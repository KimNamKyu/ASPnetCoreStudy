using EntityFrameworkCore_2_.Data;
using EntityFrameworkCore_2_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
                // 2) List<User> selectList = db.Users.ToList();
                // 3) IEnumerable<User> selectList = db.Users.AsEnumerable(); //열거형태처럼 asenumeable을 사용하여 반환하도록

                // Linq to Sql 로 Sql문을 C#코드에서 작성하여 사용의 편의성을 높임 한국에서는 별로 없다네
                //IQueryable<User> selectList = from user in db.Users select user;  // Linq to Sql

                /*************************************************************************************************
                 * Linq / EntitiyFramework 잘쓰는 법
                 * # IEnumerable vs IQueryable
                 * Extension Query => 작성이 가능
                 * 1. IEnumerable => 쿼리 => 데이터 => Client (사용자) 컴퓨터 메모리에 담아놓는것 => Slow => *클라이언트 메모리 사용 / 서버 부담적다.
                 * 2. IQueryable => 쿼리 => 데이터(10명) => Server 메모리에 담김.=> (OrderBy, Where) Fast => 서버자원사용
                **************************************************************************************************/

                #region + INSERT 쿼리
                // 2. INSERT 쿼리
                // db.Users.Add(User);
                // db.SaveChanges(); //실행을 해야 Insert가능

                //var user = new User
                //{
                //    UserId = 3,
                //    UserName = "임길동",
                //    Birth = "808080"
                //};

                //db.Users.Add(new User
                //{
                //    UserId = 3,
                //    UserName = "임길동",
                //    Birth = "801010"
                //});

                //db.SaveChanges();   //commit 과 동일한 개념!
                //Console.WriteLine("Insert 완료?"); 
                #endregion

                /*************************************************************************************************/

                #region + UPDATE 쿼리
                // 3. UPDATE 쿼리
                // db.Entry(T).State = EntityState.Modified;

                //var user = new User { UserId = 1, UserName = "장길동" };
                //db.Entry(user).State = EntityState.Modified;
                //db.SaveChanges(); 
                #endregion

                /*************************************************************************************************/

                #region + Delete 쿼리
                // 4. Delete 쿼리
                // DELETE FROM User WHERE UserId = 2;
                // db.Users.Remove(T);
                // db.SaveChanges();

                //var user = new User { UserId = 2};
                //db.Users.Remove(user);
                //db.SaveChanges(); 
                #endregion


                //foreach (var item in selectList)
                //{
                //    Console.WriteLine(item.UserName);
                //}

                /************************************************* ************************************************/
                #region +  Linq의 분류 2가지
                // # Linq 분류 (2가지)
                // 1. 쿼리 구문 => 복잡성이 있다면
                // from user in users 
                // where ...
                // select new ....

                // 2. 메서드 구문 => 직관적 
                // db.Users.Where().ToList(); 
                #endregion

                /************************************************* ************************************************/

                #region + Where 절 
                // .Where()  :: 리스트가 가능한 조건절
                // 1.   .Where() -> 조건절 -> 리스트가 가능하다. (존재이유)
                // SELECT * FROM Users WHERE UserId = 1;

                //var list = db.Users.ToList();
                var list = db.Users.Where(u => u.UserId == 3);

                foreach (var user in list)
                {
                    Console.WriteLine($"아이디 : {user.UserId}  이름 : {user.UserName}({user.Birth})");
                }
                Console.WriteLine("------------------------------");
                // 게시물 1개 수정 -> primary key  값 으로 데이터 가져옴.(하나만 가져올때는 where절 X)
                // 특정 데이터 1개 가져오기
                // .First(), FirstOrDefault(), .Single(), .SingleOrDefault()

                // SingleOrDefault() => 두개이상 결과가 있을때만 오류 (데이터가 없을때는 오류 X) 
                // FirstOrDefault() => 두개이상이 와도 하나만 가져옴( 그 데이터가 정확한지 모름 )

                // FirstOrDefault() 권장
                // 중복되지 않는 조건을 사용하기 => identify 유일한 값을 가진 컬럼! ( Primary key로만 가져온다면 => 안정적 )
                var user2 = db.Users.First(); // Users테이블에서 한명만 가져오겟다.
                // SELECT TOP 1 * FROM Users 
                Console.WriteLine($"아이디 : {user2.UserId}  이름 : {user2.UserName}({user2.Birth})");
                Console.WriteLine("------------------------------");
                var user3 = db.Users.First(u => u.UserId == 1);
                // SELECT TOP 1* FROM Users WHERE UserName = '홍길동';
                Console.WriteLine($"아이디 : {user3.UserId}  이름 : {user3.UserName}({user3.Birth})");
                #endregion

                /************************************************* ************************************************/
                
                #region + OrderBy 절
                // # OrderBy( ) => 오름 차순
                // 1,2,3,4,5,6
                Console.WriteLine("------------------------------");
                // # OrderByDecendingBy( )  => 내림차순
                // 6,5,4,3,2,1
                var list2 = db.Users.OrderByDescending(u => u.UserId).ToList();
                foreach (var user in list2)
                {
                    Console.WriteLine($"아이디 : {user.UserId}  이름 : {user.UserName}({user.Birth})");
                } 
                #endregion
            }
        }
    }
}
