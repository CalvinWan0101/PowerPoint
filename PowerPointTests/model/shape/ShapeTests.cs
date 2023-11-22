using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace PowerPoint.model.shape.test {
    [TestClass]
    public class ShapeTests {

        const string COMMA = ", ";
        const string TEMPLATE = "({0:D3}, {1:D3})";

        Factory _factory;

        [TestInitialize]
        public void Initialize() {
            _factory = new Factory();
        }

        [TestMethod]
        // make sure constructor work
        public void make_sure_constructor_work() {
        }
    }
}