using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            #region + Non Generic Collection
            // 1) Non Generic Collection
            //ArrayList list = new ArrayList();

            //list.Add("Dotnet");
            //list.Add(2.1);
            //list.Add("ASP.NET Core");

            ////반복구문 사용하여 출력  ArrayList는 리스트에 아이템이 점점 추가가 된다면 foreach를 사용하는게 좋다.
            //foreach(var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadLine();
            #endregion

            #region + Generic Collection
            // 2) Generic Collection example
            // select 에서 특정하나만 가져오거나 전체 row를 가져올때 사용할때 상세하게 설명 가능. 
            // List<T> ();  T : 자료형이 될수 있고 calss 객체가 될수있다.
            List<int> list = new List<int> //int 숫자를 담는 list
            {
                1,2,3,4,5
            };
            // list.Count 는 Generic Collection에서 사용한것 
            Console.WriteLine(list.Count);

            ICollection<int> enumerableList = list;
            enumerableList.Clear();

            //Enumerable 에서 카운트를 굳이 사용하고 싶으면 Linq쿼리식를 사용해라  => Count()
            Console.WriteLine(enumerableList.Count);

            //foreach(var number in list)
            //{
            //    Console.WriteLine(number);
            //}

            // 3. 정리 : EntityFramework 에서 List<T>, IEnumerable<T> 사용하게 될것
            #endregion
        }
    }
}
