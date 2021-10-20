using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Authentication;
using UserManagement.Models;



namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    //[Authorize]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MessageModels
        [HttpGet("{name}")]
      
        public IEnumerable<MessageModel> Get(string name)
        {


            var messages = new List<MessageModel>();


            var query = $"SELECT * FROM dbo.Messages WHERE MsgFrom='{name}' OR MsgTo='{name}'";

           // using (var context = new ())
            {
                try
                {
                    messages = _context.Messages.FromSqlRaw(query).ToList<MessageModel>();

                    return messages;


                }
                catch (Exception e)
                {
                    return messages;
                }
            }
        }

        //GET: api/MessageModels/5
        //[HttpGet("{id}")]
        public async Task<ActionResult<MessageModel>> GetMessageModel(int id)
        {
            var messageModel = await _context.Messages.FindAsync(id);

            if (messageModel == null)
            {
                return NotFound();
            }

            return messageModel;
        }

        // PUT: api/MessageModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutMessageModel(int id, MessageModel messageModel)
        {
            if (id != messageModel.MsgId)
            {
                return BadRequest();
            }

            _context.Entry(messageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new Response { Status = "Success", Message = "Message Updated" });
        }

        // POST: api/MessageModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageModel>> PostMessageModel(MessageModel messageModel)
        {
            _context.Messages.Add(messageModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageModel", new { id = messageModel.MsgId }, messageModel);
        }

        // DELETE: api/MessageModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageModel(int id)
        {
            var messageModel = await _context.Messages.FindAsync(id);
            if (messageModel == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(messageModel);
            await _context.SaveChangesAsync();

            return Ok(new Response { Status = "Success", Message = "Message deleted" });
        }

        private bool MessageModelExists(int id)
        {
            return _context.Messages.Any(e => e.MsgId == id);
        }
    }

}
