using Izuran.Data;
using Izuran.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Izuran.Controllers
{
    
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;
        public ItemsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        
        public async Task<ActionResult<List<Item>>> GetItemsAsync()
        {
           
            return await _context.Items.FromSql($"EXECUTE dbo.GetItems").ToListAsync();
        }
    }
}
