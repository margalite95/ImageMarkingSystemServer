using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.DTO.Requests
{
   public class EditColorRequest
    {
        public string DocID { get; set; }
        public string MarkerID { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public string UserID { get; set; }
    }
}
