using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model;
using PowerPoint.model.command;
using PowerPoint.model.state;

namespace PowerPointTests.model.command {
    [TestClass]
    public class AddCommandTest {
        DrawingState _drawingState;
        PointState _pointState;
        Model _model;

        [TestInitialize]
        public void initialize() {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
        }

        [TestMethod]
        public void make_sure_constructor_work() {
        }

        [TestMethod]
        public void execute_add_command() {
            _model.Add("Line");
            Assert.AreEqual(1, _model.GetShapes().GetListOfShape().Count);
            Assert.AreEqual("Line", _model.GetShapes().GetListOfShape()[0].Name);
        }

        [TestMethod]
        public void undo_add_command() {
            _model.Add("Line");
            Assert.AreEqual(1, _model.GetShapes().GetListOfShape().Count);
            Assert.AreEqual("Line", _model.GetShapes().GetListOfShape()[0].Name);

            _model.Undo();
            Assert.AreEqual(0, _model.GetShapes().GetListOfShape().Count);
        }

        [TestMethod]
        public void set_and_get_id() {
            AddCommand addCommand = new AddCommand(_model, "Line");
            addCommand.Id = "123";
            Assert.AreEqual("123", addCommand.Id);
        }
    }
}