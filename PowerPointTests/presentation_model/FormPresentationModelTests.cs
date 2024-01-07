using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using PowerPointTests.model;
using System.Drawing;
using PowerPointTests.model.shape;

namespace PowerPoint.presentation_model.Tests
{
    [TestClass]
    public class FormPresentationModelTests
    {
        FakeModel _fakeModel;
        FormPresentationModel _prModel;

        private int _notifyPropertyChangedCount = 0;

        private void NotifyPropertyChangedCount()
        {
            _notifyPropertyChangedCount++;
        }

        [TestInitialize]
        public void Initialize()
        {
            _fakeModel = new FakeModel();
            _prModel = new FormPresentationModel(_fakeModel);
            _prModel.PropertyChanged += NotifyPropertyChangedCount;
        }

        [TestMethod]
        public void notify_property_changed()
        {
            _prModel.NotifyPropertyChanged();
            _prModel.NotifyPropertyChanged();
            Assert.AreEqual(2, _notifyPropertyChangedCount);
        }

        [TestMethod]
        public void line_button_checked()
        {
            _prModel.LineButtonChecked = true;
            Assert.AreEqual(true, _prModel.LineButtonChecked);
            Assert.AreEqual(1, _notifyPropertyChangedCount);
        }

        [TestMethod]
        public void rectangle_button_checked()
        {
            _prModel.RectangleButtonChecked = true;
            Assert.AreEqual(true, _prModel.RectangleButtonChecked);
            Assert.AreEqual(1, _notifyPropertyChangedCount);
        }

        [TestMethod]
        public void circle_button_checked()
        {
            _prModel.CircleButtonChecked = true;
            Assert.AreEqual(true, _prModel.CircleButtonChecked);
            Assert.AreEqual(1, _notifyPropertyChangedCount);
        }

        [TestMethod]
        public void mouse_button_checked()
        {
            _prModel.MouseButtonChecked = true;
            Assert.AreEqual(true, _prModel.MouseButtonChecked);
            Assert.AreEqual(1, _notifyPropertyChangedCount);
        }

        [TestMethod]
        public void draw_ratio() 
        {
            _prModel.DrawRatio = 2;
            Assert.AreEqual(2, _prModel.DrawRatio);
        }

        [TestMethod]
        public void preview_draw_ratio()
        {
            _prModel.PreviewDrawRatio = 2;
            Assert.AreEqual(2, _prModel.PreviewDrawRatio);
        }

        [TestMethod]
        public void draw_shape_and_preview()
        {
            _prModel.Draw(Graphics.FromImage(new Bitmap(50, 50)));
            _prModel.PreviewDraw(Graphics.FromImage(new Bitmap(50, 50)), 0);
            Assert.AreEqual(2, _fakeModel.DrawUsed);
        }

        [TestMethod]
        public void click_line_button()
        {
            _prModel.LineButtonChecked = false;
            _prModel.ClickLineButton();

            Assert.AreEqual(1, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual("Line", _fakeModel.ShapeName);
            Assert.IsTrue(_prModel.LineButtonChecked);
            Assert.IsFalse(_prModel.RectangleButtonChecked);
            Assert.IsFalse(_prModel.CircleButtonChecked);
            Assert.IsFalse(_prModel.MouseButtonChecked);

            _prModel.ClickLineButton();

            Assert.AreEqual(2, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual(null, _fakeModel.ShapeName);
            Assert.IsTrue(_prModel.MouseButtonChecked);
        }

        [TestMethod]
        public void click_rectangle_button()
        {
            _prModel.RectangleButtonChecked = false;
            _prModel.ClickRectangleButton();

            Assert.AreEqual(1, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual("Rectangle", _fakeModel.ShapeName);
            Assert.IsFalse(_prModel.LineButtonChecked);
            Assert.IsTrue(_prModel.RectangleButtonChecked);
            Assert.IsFalse(_prModel.CircleButtonChecked);
            Assert.IsFalse(_prModel.MouseButtonChecked);

            _prModel.ClickRectangleButton();

            Assert.AreEqual(2, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual(null, _fakeModel.ShapeName);
            Assert.IsTrue(_prModel.MouseButtonChecked);
        }

        [TestMethod]
        public void click_circle_button()
        {
            _prModel.CircleButtonChecked = false;
            _prModel.ClickCircleButton();

            Assert.AreEqual(1, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual("Circle", _fakeModel.ShapeName);
            Assert.IsFalse(_prModel.LineButtonChecked);
            Assert.IsFalse(_prModel.RectangleButtonChecked);
            Assert.IsTrue(_prModel.CircleButtonChecked);
            Assert.IsFalse(_prModel.MouseButtonChecked);

            _prModel.ClickCircleButton();

            Assert.AreEqual(2, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual(null, _fakeModel.ShapeName);
            Assert.IsTrue(_prModel.MouseButtonChecked);
        }

        [TestMethod]
        public void click_mouse_button()
        {
            _prModel.MouseButtonChecked = false;
            _prModel.ClickMouseButton();

            Assert.AreEqual(1, _fakeModel.SetShapeNameUsed);
            Assert.AreEqual(null, _fakeModel.ShapeName);
            Assert.IsFalse(_prModel.LineButtonChecked);
            Assert.IsFalse(_prModel.RectangleButtonChecked);
            Assert.IsFalse(_prModel.CircleButtonChecked);
            Assert.IsTrue(_prModel.MouseButtonChecked);

            _prModel.ClickMouseButton();

            Assert.AreEqual(1, _fakeModel.SetShapeNameUsed);
        }

        [TestMethod]
        public void mouse_press()
        {
            _prModel.MousePress(new PointF(0, 0));

            Assert.AreEqual(1, _fakeModel.MousePressUsed);
        }

        [TestMethod]
        public void mouse_move()
        {
            _prModel.MouseMove(new PointF(0, 0));

            Assert.AreEqual(1, _fakeModel.MouseMoveUsed);
        }

        [TestMethod]
        public void mouse_release()
        {
            _prModel.MouseRelease(new PointF(0, 0));

            Assert.AreEqual(1, _fakeModel.MouseReleaseUsed);
            Assert.IsTrue(_prModel.MouseButtonChecked);
            Assert.IsFalse(_prModel.LineButtonChecked);
            Assert.IsFalse(_prModel.RectangleButtonChecked);
            Assert.IsFalse(_prModel.CircleButtonChecked);
        }

        [TestMethod]
        public void clear()
        {
            _prModel.Clear();

            Assert.AreEqual(1, _fakeModel.ClearUsed);
        }
    }
}