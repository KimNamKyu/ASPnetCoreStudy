using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPnetCoreMVC.DataContext;
using ASPnetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPnetCoreMVC.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Session 이 있는 경우
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            //var list = new List<Note>();
            using (var db = new ASPnetNoteDbContext())
            {
                var list = db.Notes.ToList();   //DB의 모든 정보 List Generic 
                return View(list);
                //페이지 네이션 page nation =>  별도 처리 
            }
        }

        /// <summary>
        /// 게시판 상세 정보
        /// </summary>
        /// <param name="noteNo"></param>
        /// <returns></returns>
        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            using (var db = new ASPnetNoteDbContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.NoteNo.Equals(noteNo));
                return View(note);
            }
        }

        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            //Session 이 있는 경우
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        /// <summary>
        /// 게시물 Post전송 Overloding
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Note model)
        {
            //Session 이 있는 경우
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            //로그인 성공 상태
            //model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            model.UserNo = Convert.ToInt32(HttpContext.Session.GetInt32("USER_LOGIN_KEY"));
            // 제목 , 내용 , 작성자 를 입력받는다.
            if (ModelState.IsValid)
            {
                using (var db = new ASPnetNoteDbContext())
                {
                    db.Notes.Add(model);    //DB 추가

                    if (db.SaveChanges() > 0)
                    {
                        return Redirect("Index"); // RedirectToAction("Index", "Note");  NoteController 의 Index로 같은 의미!
                    }
                }
                //전역적인 오류 메세지
                ModelState.AddModelError(string.Empty, "게시물을 저장할 수 없습니다.");
            }
            return View(model); //error 시 model을 다시 넘겨준다.
        }
        

        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            //Session 이 있는 경우
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            //Session 이 있는 경우
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                // 로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
