using System.ComponentModel.DataAnnotations;

namespace ASPnetCoreMVC.Models
{
    public class User
    {
        // 코드 First 방식
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]   // PK 설정 하는 annotation
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage ="사용자 이름을 입력하세요")]      // Not null 설정
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "사용자 ID를 입력하세요")]      // Not null 설정
        public string UserId { get; set; }

        /// <summary>
        /// 사용자 패스워드
        /// </summary>
        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요")]      // Not null 설정
        public string UserPassword { get; set; }
    }
}
