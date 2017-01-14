using System;
using System.Collections.Generic;
using ConductOfCode.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ConductOfCode.Controllers
{
    [Route("api/[controller]")]
    public class StackController : Controller
    {
        private static Stack<Item> Stack = new Stack<Item>();

        [HttpPost("[action]")]
        [SwaggerResponse(typeof(void))]
        public IActionResult Clear()
        {
            Stack.Clear();

            return NoContent();
        }

        [HttpGet("[action]")]
        [SwaggerResponse("200", typeof(Item))]
        [SwaggerResponse("400", typeof(Error))]
        public IActionResult Peek()
        {
            try
            {
                return Ok(Stack.Peek());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new Error(ex));
            }
        }

        [HttpGet("[action]")]
        [SwaggerResponse("200", typeof(Item))]
        [SwaggerResponse("400", typeof(Error))]
        public IActionResult Pop()
        {
            try
            {
                return Ok(Stack.Pop());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new Error(ex));
            }
        }

        [HttpPost("[action]")]
        [SwaggerResponse(typeof(void))]
        public IActionResult Push([FromBody] Item item)
        {
            Stack.Push(item);

            return NoContent();
        }

        [HttpGet("[action]")]
        [SwaggerResponse(typeof(Item[]))]
        public Item[] ToArray()
        {
            return Stack.ToArray();
        }
    }
}