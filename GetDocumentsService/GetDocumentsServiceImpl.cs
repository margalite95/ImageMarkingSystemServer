using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using System;
using System.Collections.Generic;


namespace GetDocumentsService
{
    [Register(Policy.Transient, typeof(IGetDocumentsService))]
    public class GetDocumentsServiceImpl : IGetDocumentsService
    {
        IImageMarkingDocumentsDAL _dalDoc;
        IImageMarkingShareDocumentsDAL _dalShared;
        public GetDocumentsServiceImpl(IImageMarkingDocumentsDAL dalDoc, IImageMarkingShareDocumentsDAL dalShared)
        {
            _dalDoc = dalDoc;
            _dalShared = dalShared;
        }
        public Response GetDocuments(GetDocumentsRequest request)
        {
            try 
                {
                List<Documents> dl = new List<Documents>();
                List<Documents> sdl = new List<Documents>();
                var ds = _dalDoc.GetDocuments(request.Owner);
                var sd = _dalShared.GetSharedDocuments(request.Owner);
                var tblDocs = ds.Tables[0];
                var tblShareDocs = sd.Tables[0];
                GetDocumentsResponse retval = new GetDocumentsNotExistsResponse();
                if (tblDocs.Rows.Count > 0 || tblShareDocs.Rows.Count>0)
                {
                    for (int i = 0; i < tblDocs.Rows.Count; i++)
                    {
                        if (request.Owner == (string)tblDocs.Rows[i][0])
                        {
                            Documents dc = new Documents((string)tblDocs.Rows[i][0], (string)tblDocs.Rows[i][1],
                            (string)tblDocs.Rows[i][2], (string)tblDocs.Rows[i][3]);
                            dl.Add(dc);
                        }   
                    }
                    for (int i1 = 0; i1 < tblShareDocs.Rows.Count; i1++)
                    {
                        if (request.Owner != (string)tblShareDocs.Rows[i1][0])
                        {
                            Documents sdc = new Documents((string)tblShareDocs.Rows[i1][0], (string)tblShareDocs.Rows[i1][1],
                                (string)tblShareDocs.Rows[i1][2], (string)tblShareDocs.Rows[i1][3]);
                            sdl.Add(sdc);
                        }
                    }
                    retval = new GetDocumentsResponseOK(dl,sdl);
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

