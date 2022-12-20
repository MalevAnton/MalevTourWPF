using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ToruMalev
{
    partial class Tour
    {
        public SolidColorBrush Is_ActualColor
        {
            get
            {
                switch (Is_Actual)
                {
                    case true: return Brushes.Green;
                    default: return Brushes.Red;
                }
            }
        }

        public string Is_ActualText
        {
            get
            {
                switch (Is_Actual)
                {
                    case true: return "Актуально";
                    default: return "Не актуально";
                }
            }
        }
    }
}
