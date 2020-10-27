using DIContract;
using ImageMarkingContract.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMarkingContract.Interface.BLL
{
    public interface IEditColorsService
    {
        Response EditColors(EditColorRequest request);
    }
}
