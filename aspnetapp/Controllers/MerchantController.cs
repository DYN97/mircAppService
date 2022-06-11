using aspnetapp.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetapp.Controllers
{
    [Route("api/Merchant")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly CounterContext _context;

        public MerchantController(CounterContext context)
        {
            _context = context;
        }
        // GET: api/count.
        [Route("register")]
        [HttpPost]
        public ActionResult<Response> RegisterMerchant(Merchant request)
        {
            var header = Request.Headers;
            var Merchant = new Merchant
            {
                Mobile = Convert.ToInt32(request.Mobile),
                Open_id = header["X-WX-OPENID"].ToString(),
                Create_time = DateTime.Now,
                Update_Time = DateTime.Now
            };
            try
            {
                var result = _context.Merchants.Add(Merchant);
                return new Response { Data = result.Entity, Message = "创建成功！" };
            }
            catch (Exception e)
            {
                return new Response { Code = 999, Message = e.Message };
            }

        }

        [Route("vehiclelist")]
        [HttpGet]
        public ActionResult<Response> GetVehicleList()
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

                var result = _context.Vehicle.Where(t => t.CustomerID == customer.Id && t.Is_Deleted == 0).ToList();
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
                else
                {
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
    }
}
