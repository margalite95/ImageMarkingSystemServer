using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.DTO.Responses;
using ImageMarkingContract.Interface;
using System;

namespace RemoveMakerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]

    public class RemoveMakerServiceImpl: IRemoveMarkerService
    {
        IMessanger _messanger;
        IImageMarkingMarkerDAL _dal;
        public RemoveMakerServiceImpl(IImageMarkingMarkerDAL dal, IMessanger messanger)
        {
            _dal = dal;
            _messanger = messanger;
        }

        public Response RemoveMarker(RemoveMarkerRequest request)
        {
            try
            {
                var ds = _dal.RemoveMarker(request.DocID, request.MarkerID);
                var tbl = ds.Tables[0];
                RemoveMarkerResponse retval = new RemoveMarkerResponse();
                if (tbl.Rows.Count == 0)
                {
                    retval = new RemoveMarkerResponseOK(request);
                    _messanger.Send(request.MarkerID, request.DocID, "removeMarker");
                }

                return retval;
            }

            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }


        }
    }
    }

