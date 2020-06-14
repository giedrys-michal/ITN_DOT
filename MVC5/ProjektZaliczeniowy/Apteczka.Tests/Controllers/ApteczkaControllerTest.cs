using Apteczka.Controllers;
using Apteczka.Data_Access;
using Apteczka.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [TestCase(10)] // Nie mam tylu apteczek w bazie
        public void DetailsViewNotNull(int? id)
        {
            ViewResult result = aptC.Details(id) as ViewResult;
            Assert.IsNotNull(result);
        }
        [Test]
        public void DetailsTitleString()
        {
            ViewResult result = aptC.Details(1) as ViewResult;
            Assert.AreEqual("Szczegóły", result.ViewBag.Title); // Nie widzi właściwości ViewBag.Title widoku Details
        }

        [TestCase(1)] // Jak przekazać dane z widoku do akcji??
        public void EditNameById(int id)
        {
            //ControllerContext ctrlContext = new ControllerContext();
            //string nameInDB = aptContext.ApteczkiDB.Find(id).Nazwa;
            //string nameExpected = "TestApteczka";

            //ViewResult result = aptC.EditPost(id) as ViewResult;
            //result.ExecuteResult(ctrlContext);
        }
    }
}
