﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalProject.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BookingController : ApiController
    {
        [Route("api/booking/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = BookingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/booking/{id}")]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var data = BookingService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/booking/add")]
        [HttpPost]
        public HttpResponseMessage Add(BookingDTO ct)
        {
            try
            {
                var data = BookingService.Add(ct);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/booking/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(BookingDTO ct)
        {
            try
            {
                BookingService.Update(ct);
                return Request.CreateResponse(HttpStatusCode.OK, "Booking updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating booking", e);
            }
        }

        [Route("api/booking/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                BookingService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Created, "Booking delete successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting booking", e);
            }
        }

        [Route("api/booking/{id}/payment")]
        [HttpGet]
        public HttpResponseMessage GetPayments(string id)
        {
            try
            {
                var data = BookingService.GetwithPayments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}