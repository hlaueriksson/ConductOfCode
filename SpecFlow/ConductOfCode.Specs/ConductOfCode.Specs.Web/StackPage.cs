using System.Collections.Generic;
using System.Linq;
using Coypu;

namespace ConductOfCode.Specs
{
    public class StackPage : BasePage
    {
        public ElementScope Result => Browser.FindId("result");

        public ElementScope Error => Browser.FindId("error");

        public void Visit()
        {
            Browser.Visit("/");
        }

        public void Clear()
        {
            Browser.ClickButton("clear");
        }

        public ElementScope Peek()
        {
            Browser.ClickButton("peek");

            return Result;
        }

        public ElementScope Pop()
        {
            Browser.ClickButton("pop");

            return Result;
        }

        public void Push(string item)
        {
            Browser.FillIn("value").With(item);

            Browser.ClickButton("push");
        }

        public IEnumerable<string> ToArray()
        {
            var items = Browser.FindAllCss(".item");

            return items.Select(x => x.Text);
        }
    }
}