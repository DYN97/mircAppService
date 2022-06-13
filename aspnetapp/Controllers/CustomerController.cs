#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetapp;
using aspnetapp.models;
using System.Net.Mime;

namespace aspnetapp.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CounterContext _context;

        public CustomerController(CounterContext context)
        {
            _context = context;
        }
        // GET: api/count.
        [Route("register")]
        [HttpPost]
        public ActionResult<Response> RegisterCustomer([FromForm] CustomerRequest data)
        {
            var header = Request.Headers;
           /* if (string.IsNullOrEmpty(request.merchant_id))
            {
                return new Response { Code = 999, Message = "商户不存在" };
            }
            var merchant = _context.Merchants.Find(Convert.ToInt32(request.merchant_id));
            if (merchant == null)
            {
                return new Response { Code = 999, Message = "商户不存在" };
            }*/
            var customer = new Customer();
            // customer.Mobile = Convert.ToInt32(request.mobile);
            customer.Open_id = header["X-WX-OPENID"].ToString();
            customer.Create_time = DateTime.Now;
            customer.Update_time = DateTime.Now;
            try
            {
                var result = _context.Customers.Add(customer);
                return new Response { Data = result.Entity, Message = "创建成功！" };
            }
            catch (Exception e)
            {
                return new Response { Code = 999, Message = e.Message };
            }
            
        }

        [Route("vehiclelist")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetVehicleList()
        {
            var header = Request.Headers;
            var openId = header["X-WX-OPENID"].ToString();
            if (string.IsNullOrEmpty(openId))
            {
                return new Response { Code = 999, Message = "环境信息有误！" };
            }
            try
            {
                
                var customer = await _context.Customers.FirstOrDefaultAsync(t => t.Open_id == openId);
                if (customer == null) {
                    return new Response { Code = 999, Message = "用户信息获取失败！" };
                }
                var result = _context.Vehicle.Where(t=>t.CustomerID == customer.Id&&t.Is_Deleted == 0).ToList();
                return new Response { Data = result, Message = "获取成功！" };
            }
            catch (Exception e)
            {
                return new Response { Code = 999, Message = e.Message };
            }
        }
        [Route("editVehicle")]
        [Route("createVehicle")]
        [HttpPost]
        public ActionResult<Response> ChangeVehicle(VehicleRequest request)
        {
            var header = Request.Headers;
            var openId = header["X-WX-OPENID"].ToString();
            var customer = _context.Customers.Single(t => t.Open_id == openId);
            try
            {
                if (customer == null)
                {
                    return new Response { Code = 999, Message = "用户信息获取失败！" };
                }
                if (request.VehicleId.HasValue)
                {
                    var vehicle = _context.Vehicle.Find(request.VehicleId);
                    vehicle.License_Plate = request.LicensePlate;
                    vehicle.Brand_Name = request.BrandName;
                    vehicle.Mileage = request.Mileage;
                    vehicle.Production_Name = request.ProductionName;
                    var result = _context.Update(vehicle);
                    return new Response { Data = result, Message = "修改成功！" };
                }
                else {
                    var newVehicle = new Vehicle
                    {
                        Brand_Name = request.BrandName,
                        CustomerID = customer.Id,
                        License_Plate = request.LicensePlate,
                        Mileage = request.Mileage,
                        Production_Name = request.ProductionName,
                        Create_Time = DateTime.Now,
                        Update_Time = DateTime.Now
                    };
                    var result = _context.Vehicle.Add(newVehicle);
                    return new Response { Data = result, Message = "添加成功！" };
                }
               
            }
            catch (Exception e)
            {
                return new Response { Code = 999, Message = e.Message };
            }
        }
        [Route("deleteVehicle")]
        public ActionResult<Response> ChangeVehicle(string vehicleId)
        {
            var header = Request.Headers;
            var openId = header["X-WX-OPENID"].ToString();
            var customer = _context.Customers.Single(t => t.Open_id == openId);
            try
            {
                if (customer == null)
                {
                    return new Response { Code = 999, Message = "用户信息获取失败！" };
                }
                    var vehicle = _context.Vehicle.Find(Convert.ToInt32(vehicleId));
                    vehicle.Is_Deleted = 1;
                    var result = _context.Update(vehicle);
                    return new Response { Data = result, Message = "删除成功！" };
            }
            catch (Exception e)
            {
                return new Response { Code = 999, Message = e.Message };
            }
        }
        [Route("test")]
        public ActionResult<Response> test()
        {
            return new Response { Code = 999, Message = "没问题" };
        }
    }
}
