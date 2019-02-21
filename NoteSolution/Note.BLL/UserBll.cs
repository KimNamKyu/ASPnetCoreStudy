using Note.DAL;
using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;

namespace Note.BLL
{
    public class UserBll 
    {
        //강한결합
        //private UserDal _userDal = new UserDal();

        //느슨한 결합 :: 인터페이스는 구체화된 클래스가 아니므로 생성자가 만들어지지않아
        private readonly IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(int userNo)
        {
            return _userDal.GetUser(userNo);
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
