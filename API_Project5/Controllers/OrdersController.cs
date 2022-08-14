using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project5.Models;
using API_Project5.DTO;

namespace API_Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public OrdersController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [Route("GetOrderCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetOrderCount()
        {
            return _context.Orders.ToList().Count();
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.IdOrder)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        //{
        //    _context.Orders.Add(orders);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrders", new { id = orders.IdOrder }, orders);
        //}
        [HttpGet]
        [Route("GetDetailOrder/{id}")]
        public async Task<ActionResult<IEnumerable<HoaDon_DTO>>> GetDetailOrder( int id)
        {

//

            var detail = new List<HoaDon_DTO>();
            {
                var order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    var odDetail = await _context.OrderDetails.Where(s => s.IdOrder == id).ToArrayAsync();
                    foreach (var ab in odDetail)
                    {
                        var Ship = await _context.Shipping.FindAsync(id);
                        //var giaDV = await _context.GiaDichVus.FindAsync(kh.DichVuId);
                        var a = new HoaDon_DTO
                        {
                      
                        //chiTietHDs = push (ab),
                        Ship = Ship,
                           // giaDV = giaDV
                        };

                        detail.Add(a);
                    }
                    return detail;
                }
                else
                    return NotFound();

            }
           

//

        }
        //public async Task<ActionResult<IEnumerable<Products>>> Get_CateId(int cteid)
        //{
        //    return await _context.Products.Where(e => e.IdCategory == cteid).ToListAsync();
        //    //  return Get_CateID;
        //}
        //public async Task<ActionResult<IEnumerable<Products>>> SearchByName(string name)
        //{
        //    return await _context.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        //}
        [HttpPost]
        public async Task<ActionResult<HoaDon_DTO>> PostOrders(HoaDon_DTO hoaDon_DTO)
        {
            //var Customer = await _context.Customers.FindAsync(hoaDon_DTO.hoaDon.IdCustomer);
            //if (Customer != null)
            //{
                await _context.Orders.AddAsync(hoaDon_DTO.hoaDon);
                await _context.SaveChangesAsync();
                int id = hoaDon_DTO.hoaDon.IdOrder;

            OrderDetails[] chiTietHD = hoaDon_DTO.chiTietHDs;
            for (int i = 0; i < chiTietHD.Length; i++)
            {
                chiTietHD[i].IdOrder = id;
                await _context.OrderDetails.AddAsync(chiTietHD[i]);
                await _context.SaveChangesAsync();
            };
         
            var Shipping = new Shipping()
                    {
                    //ShipId = id,
                    idOrder=id,
                    CustomerName = hoaDon_DTO.Ship.CustomerName,
                    CustomerEmail = hoaDon_DTO.Ship.CustomerEmail,
                    CustomerPhone = hoaDon_DTO.Ship.CustomerPhone,
                    Payments = hoaDon_DTO.Ship.Payments,
                    NameOnCard = hoaDon_DTO.Ship.NameOnCard,
                    CardNumber = hoaDon_DTO.Ship.CardNumber,
                    IssueDate=hoaDon_DTO.Ship.IssueDate,
                    address=hoaDon_DTO.Ship.address
                };                            
                await _context.Shipping.AddAsync(Shipping);
                await _context.SaveChangesAsync();
                //var ds = await _context.Orders.FindAsync(hoaDon_DTO.chiTietHDs.IdOrder);
                //ds.Status = true;
                await _context.SaveChangesAsync();
                return hoaDon_DTO;
            //}
            //else
            //    return NotFound();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.IdOrder == id);
        }
    }
}
