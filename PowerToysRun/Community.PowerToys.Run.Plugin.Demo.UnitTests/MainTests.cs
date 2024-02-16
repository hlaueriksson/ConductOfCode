using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Community.PowerToys.Run.Plugin.Demo.UnitTests
{
    [TestClass]
    public class MainTests
    {
        private Main _subject = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            _subject = new Main();
        }

        [TestMethod]
        public void Query_should_calculate_the_number_of_words()
        {
            var results = _subject.Query(new(""));
            Assert.AreEqual("Words: 0", results[0].Title);

            results = _subject.Query(new("Hello World"));
            Assert.AreEqual("Words: 2", results[0].Title);
        }

        [TestMethod]
        public void Query_should_calculate_the_number_of_characters()
        {
            var results = _subject.Query(new(""));
            Assert.AreEqual("Characters: 0", results[1].Title);

            results = _subject.Query(new("Hello World"));
            Assert.AreEqual("Characters: 10", results[1].Title);
        }

        [TestMethod]
        public void LoadContextMenus_should_return_buttons_for_words_result()
        {
            var results = _subject.LoadContextMenus(new() { ContextData = (2, TimeSpan.FromSeconds(3)) });
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Copy (Enter)", results[0].Title);
            Assert.AreEqual("Copy time (Ctrl+Enter)", results[1].Title);
        }

        [TestMethod]
        public void LoadContextMenus_should_return_button_for_characters_result()
        {
            var results = _subject.LoadContextMenus(new() { ContextData = 10 });
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Copy (Enter)", results[0].Title);
        }

        [TestMethod]
        public void AdditionalOptions_should_return_option_for_CountSpaces()
        {
            var options = _subject.AdditionalOptions;
            Assert.AreEqual(1, options.Count());
            Assert.AreEqual("CountSpaces", options.ElementAt(0).Key);
            Assert.AreEqual(false, options.ElementAt(0).Value);
        }

        [TestMethod]
        public void UpdateSettings_should_set_CountSpaces()
        {
            _subject.UpdateSettings(new() { AdditionalOptions = [new() { Key = "CountSpaces", Value = true }] });

            var results = _subject.Query(new("Hello World"));
            Assert.AreEqual("Characters: 11", results[1].Title);
        }
    }
}
