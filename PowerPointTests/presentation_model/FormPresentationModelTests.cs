using PowerPoint.presentation_model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.model;
using PowerPoint.model.shape;
using PowerPoint.model.state;
using System;
using System.Windows.Forms;

namespace PowerPoint.presentation_model.Tests
{
    [TestClass]
    public class FormPresentationModelTests
    {
        DrawingState _drawingState;
        PointState _pointState;
        Model _model;
        FormPresentationModel _formPresentationModel;

        private int _notifyPropertyChangedCount = 0;

        private void NotifyPropertyChangedCount()
        {
            _notifyPropertyChangedCount++;
        }

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _drawingState = new DrawingState(_model);
            _pointState = new PointState(_model);
            _model.SetState(_drawingState, _pointState);
            _formPresentationModel = new FormPresentationModel(_model, new Panel());
        }

    }
}