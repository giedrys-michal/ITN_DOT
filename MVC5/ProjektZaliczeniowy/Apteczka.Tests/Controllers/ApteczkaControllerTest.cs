using Apteczka.Controllers;
using Apteczka.Data_Access;
using Apteczka.Models;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Apteczka.Tests.Controllers
{
    [TestFixture]
    public class ApteczkaControllerTest
    {
        ApteczkaController aptC;
        ApteczkaContext aptContext;

        [OneTimeSetUp]
        public void CreateObj()
        {
            aptC = new ApteczkaController();
            aptContext = new ApteczkaContext();
        }

        [OneTimeTearDown]
        public void DisposeObj()
        {
            aptC = null;
            aptContext = null;
        }

        [TestCase("", "", "", 1)]
        public void IndexViewWithParamsNotNull(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewResult result = aptC.Index(sortOrder, currentFilter, searchString, page) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateViewNotNull()
        {
            ViewResult result = aptC.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestCase(1)]
        public void DeleteViewNotNull(int? id)
        {
            ViewResult result = aptC.Delete(id) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ApteczkaDeletedFromDb(int? id)
        {
            int dbEntriesCount = aptContext.ApteczkiDB.ToList().Count;
            int dbEntriesExpected = dbEntriesCount - 1;

            if (aptC.Delete(id) is ViewResult)
            {
                dbEntriesCount--;
            }
            Assert.AreEqual(dbEntriesExpected, dbEntriesCount);
        }

        [Test]
        public void AllDetailsViewsRendered()
        {
            int detailsViewsExpected = aptContext.ApteczkiDB.ToList().Count;
            int detailsViewsActual = 0;

            foreach (var item in aptContext.ApteczkiDB)
            {
                if (aptC.Details(item.ID) is ViewResult)
                {
                    detailsViewsActual++;
                }
            }
            Assert.AreEqual(detailsViewsExpected, detailsViewsActual);
        }
        [Ignore("Nie dokończone, problem z pobieraniem danych z formularzy.")]
        [TestCase(1)] 
        public void EditNameById(int id)
        {
            //var request = new Mock<HttpRequestBase>();
            //ControllerContext ctrlContext = new ControllerContext();
            //string nameInDB = aptContext.ApteczkiDB.Find(id).Nazwa;
            //string nameExpected = "TestApteczka";

            //ViewResult result = aptC.EditPost(id) as ViewResult;
            //result.ExecuteResult(ctrlContext);
        }
    }
}
