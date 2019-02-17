using System.Linq;
using ASPnetCoreMVC.DataContext;
using ASPnetCoreMVC.Models;
using ASPnetCoreMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPnetCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 로그인 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new ASPnetNoteDbContext())
                {
                    // Linq 쿼리식 - 메서드 체이닝
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                                                u.UserPassword.Equals(model.UserPassword)); //User 테이블의 첫번째값이 출력 메모리상에서 비교

                    // if else 절을 쓰면 가독성이 떨어진다. (논리적으로 봐야함)
                    if (user != null)
                    {
                        // 로그인에 성공했을때
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo); //메모리상에 사용자 정보가 등재.
                        return RedirectToAction("LoginSuccess", "Home"); //로그인 성공 페이지로 이동!
                    }
                }
                // 로그인에 실패했을때 (데이터 처리가 없기 때문에 밖에 있을 필요가 있다.)
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            //HttpContext.Session.Clear(); //모든 세션 삭제 (관리자의 명령어) 잘사용 X
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 회원가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            //벨리데이션 check
            if (ModelState.IsValid) //사용자의 필수 입력사항을 입력받앗는가? [Required] == 사용자에게 반드시 입력받아야한다고 명시
            {
                //Db open & close를 한번에 같이 가능!
                using (var db = new ASPnetNoteDbContext())
                {
                    db.Users.Add(model); //메모리상에 추가됨.
                    db.SaveChanges();  // 실제 디비에 저장.
                }
                return RedirectToAction("Index", "Home"); // Register View 에서 HomeController 의 Index로 이동시킨다.
            }
            return View(model);
        }
    }
}
