using System;

namespace ImageMarkingContract.DTO.Models
{
   public class Marker
    {
        public string DocID { get; set; }
        public string MarkerID { get; set; }
        public string MarkerType { get; set; }
        public Decimal CenterX { get; set; }
        public Decimal CenterY { get; set; }
        public Decimal RadiusX { get; set; }
        public Decimal RadiusY { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public string UserID { get; set; }
        public Marker(string docID, string markerID, string markerType,Decimal centerX,
            Decimal centery, Decimal radiusX, Decimal radiusY, string foreColor, 
            string backColor,string userID)
        {
            DocID = docID;
            MarkerID = markerID;
            MarkerType = markerType;
            CenterX = centerX;
            CenterY = centery;
            RadiusX = radiusX;
            RadiusY = radiusY;
            ForeColor = foreColor;
            BackColor = backColor;
            UserID = userID;


        }
    }
}
