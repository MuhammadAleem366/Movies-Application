using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCApp.Models;
using System.Data.Entity;
using AutoMapper;
using MVCApp.Dtos;
namespace MVCApp.Controllers.api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //GEt api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersDto = _context.Customers.
                Include(c => c.MemberShipType).
                ToList().
                Select(Mapper.Map<Customer, CustomerDto>);
            return customersDto;
        }

        //Get api/custome/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                //As Rest Api convention we have to use
                return NotFound();
            }
            //I have commenteed this because first our Action Result type was CustomerDto
            //But Now, we are just changing it to IHttpActionResult That is why we will return 
            //return Mapper.Map<Customer,CustomerDto>(customer);
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));

      }

        //Post  api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer( CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }
        
        //Put /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    } 
}
