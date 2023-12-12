﻿using System;
using System.Drawing;

namespace PowerPoint.model.command {
    public class MoveCommand : ICommand {
        private int _targetIndex;
        private PointF _originPoint1;
        private PointF _originPoint2;

        private PointF _startPoint;
        private PointF _endPoint;

        private PointF _point1;
        private PointF _point2;

        public MoveCommand(Model model, int targetIndex, PointF startPoint, PointF endPoint, PointF pointRecord1, PointF pointRecord2) : base(model) {
            _targetIndex = targetIndex;

            _startPoint = startPoint;
            _endPoint = endPoint;

            _originPoint1 = pointRecord1;
            _originPoint2 = pointRecord2;
        }

        public override void Execute() {
            _point1 = _originPoint1 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);
            _point2 = _originPoint2 + new SizeF(_endPoint.X - _startPoint.X, _endPoint.Y - _startPoint.Y);

            //_model.GetListOfShape()[_targetIndex].Move(_startPoint, _endPoint);
            _model.GetListOfShape()[_targetIndex].Point1 = _point1;
            _model.GetListOfShape()[_targetIndex].Point2 = _point2;


            _model.NotifyModelChanged();
        }

        public override void Unexcute() {
            _model.GetListOfShape()[_targetIndex].Point1 = _originPoint1;
            _model.GetListOfShape()[_targetIndex].Point2 = _originPoint2;
            _model.NotifyModelChanged();
        }
    }
}