using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgramUI_ChallOne
{
    [TestClass]
    public class ChallOneRepoTest
    {
        private MenuRepository _repo;
        private ChallOne_MenuContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            var newList = new List<string>() { "tomatoes", "beans", "olives" };
            _content = new ChallOne_MenuContent(2, "Burritos", "The best burritos on the planet!", newList, 6.95m);
            _repo.AddMenuItemSet(_content);

        }
        [TestMethod]
        public void ShouldAddToMenuItems()
        {
            //MenuRepository repo = new MenuRepository();
            //ChallOne_MenuContent test = new ChallOne_MenuContent();
            _repo.AddMenuItemSet(_content);
            List<ChallOne_MenuContent> library = _repo.GetDirectory();
            bool libraryHasTestInfo = library.Contains(_content);
            Assert.IsTrue(libraryHasTestInfo);
        }

        [TestMethod]
        public void ShouldRemoveMenuItems()
        {
            List<ChallOne_MenuContent> library = _repo.GetDirectory();
            bool removeResult = _repo.DeleteMenuItemSet(_content);
            library = _repo.GetDirectory();
            Assert.IsTrue(removeResult);
        }
    }
}
