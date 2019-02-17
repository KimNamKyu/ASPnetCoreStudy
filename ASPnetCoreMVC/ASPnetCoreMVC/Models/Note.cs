using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPnetCoreMVC.Models
{
    public class Note
    {
        /// <summary>
        /// 게시판 번호
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]      // Not null 설정
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]      // Not null 설정
        public string NoteContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]      // Not null 설정
        public int UserNo { get; set; }

        /// <summary>
        /// User No 를 통해 사용자에 접근해서 사용자의 이름을 출력 (조인) => 외래키
        /// </summary>
        [ForeignKey("UserNo")]
        public virtual User User { get; set; } //virtual 레이지 로딩 주데이터를 먼저 출력하고 비동기적으로 가져오는 의미
    }
}
