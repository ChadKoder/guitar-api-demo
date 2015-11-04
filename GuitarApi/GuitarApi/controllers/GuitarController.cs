using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuitarApi.Formatters;
using GuitarApi.Interfaces;
using GuitarApi.Queries;

namespace GuitarApi.controllers
{
    public class GuitarController : ApiController
    {
        private readonly IGetGuitarsByCompany _getGuitarsByCompany;
        private readonly IGetAllGuitars _getAllGuitars;

        public GuitarController(IGetGuitarsByCompany getGuitarsByCompany, IGetAllGuitars getAllGuitars)
        {
            _getGuitarsByCompany = getGuitarsByCompany;
            _getAllGuitars = getAllGuitars;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var results = _getAllGuitars.Select();
                return Request.CreateResponse(HttpStatusCode.OK, results, new JsonpMediaTypeFormatter(Request));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage Get(string searchText)
        {
            try
            {
                var results = _getGuitarsByCompany.Select(searchText);
                return Request.CreateResponse(HttpStatusCode.OK, results, new JsonpMediaTypeFormatter(Request));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
