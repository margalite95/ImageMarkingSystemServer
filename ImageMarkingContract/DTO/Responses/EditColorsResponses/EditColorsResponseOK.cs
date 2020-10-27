﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Responses.EditColorsResponses
{
   public class EditColorsResponseOK: EditColorsResponse
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
        public EditColorsResponseOK(string docID, string markerID, string markerType, Decimal centerX,
            Decimal centerY, Decimal rediusX, Decimal rediusY, string foreColor, string backColor, string userID)
        {
            DocID = docID;
            MarkerID = markerID;
            MarkerType = markerType;
            CenterX = centerX;
            CenterY = centerY;
            RadiusX = rediusX;
            RadiusY = rediusY;
            ForeColor = foreColor;
            BackColor = backColor;
            UserID = userID;
        }
    }
}
