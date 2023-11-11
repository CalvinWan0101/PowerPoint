﻿using PowerPoint.model;
using System.ComponentModel;
using System.Windows.Forms;

namespace PowerPoint.Properties
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected string _name
        {
            get;
            set;
        }

        public string _chineseName
        {
            get;
            protected set;
        }

        public string _information
        {
            get;
            protected set;
        }

        // function to get the name of the shape
        public abstract string GetShapeName();

        // function to get the chinese name of the shape
        public abstract string GetShapeChineseName();

        // function to get the information of the shape
        public abstract string GetInformation();

        // function to draw the shape
        public abstract void Draw(IGraphics graphics);
    }
}
