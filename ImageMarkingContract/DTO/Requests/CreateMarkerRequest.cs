using System;


namespace ImageMarkingContract.DTO.Requests
{
   public class CreateMarkerRequest
    {
        public string DocID { get; set; }
        public string MarkerType { get; set; }
        public Decimal CenterX { get; set; }
        public Decimal CenterY { get; set; }
        public Decimal RadiusX { get; set; }
        public Decimal RadiusY { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public string UserID { get; set; }
    }
}
