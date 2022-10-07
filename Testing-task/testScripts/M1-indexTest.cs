using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Testing_task.pageObject;
using TestProject_01.baseClass;

namespace Testing_task.testScripts
{
    [TestFixture]
    public class M1_index : Baseclass
    {
        [Test]
        public void enter_Several_Keywords_in_Search()
        {

            var validateSearch = new indexPage(driver);
            validateSearch.validateSearchField();
        }



        [Test]
        public void validate_web_Images()
        {

            var validateImage = new indexPage(driver);
            validateImage.checkImages();
        }


    }
}
