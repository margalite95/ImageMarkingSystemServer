using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ImageMarkingContract.Interface
{
   public interface IImageMarkingMarkerDAL
    {
        public DataSet CreateMarker(string docID, string markerID, string markerType, Decimal centerX,
        Decimal centerY, Decimal rediusX, Decimal rediusY, string foreColor, string backColor, string userID);
        public DataSet RemoveMarker(string docID, string markerID);
        public DataSet GetMarker(string docID);
        public DataSet Editcolor(string docID, string markerID, string foreColor, string backColor, string userID);

    }
}
