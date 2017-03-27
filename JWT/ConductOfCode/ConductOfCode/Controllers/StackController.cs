using System;
using System.Collections.Generic;
using System.Linq;
using ConductOfCode.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ConductOfCode.Controllers
{
    [Route("api/[controller]")]
    public class StackController : Controller
    {
        private Stack<Item> Stack { get; }

        public StackController(Stack<Item> stack)
        {
            Stack = stack;
        }

        /// <summary>Gets the number of elements contained in the Stack.</summary>
        /// <returns>The number of elements contained in the Stack.</returns>
        [HttpGet("[action]")]
        [SwaggerResponse(200, typeof(int))]
        public int Count()
        {
            return Stack.Count;
        }

        /// <summary>Removes all objects from the Stack.</summary>
        [HttpDelete("[action]")]
        [SwaggerResponse(200, typeof(void))]
        public void Clear()
        {
            Stack.Clear();
        }

        /// <summary>Determines whether an element is in the Stack.</summary>
        /// <returns>true if <paramref name="item" /> is found in the Stack; otherwise, false.</returns>
        /// <param name="item">The object to locate in the Stack.</param>
        [HttpPost("[action]")]
        [SwaggerResponse(200, typeof(bool))]
        public bool Contains([FromBody] Item item)
        {
            return Stack.Any(x => x.Value == item.Value);
        }

        /// <summary>Returns the object at the top of the Stack without removing it.</summary>
        /// <returns>The object at the top of the Stack.</returns>
        [HttpGet("[action]")]
        [SwaggerResponse(200, typeof(Item))]
        [SwaggerResponse(400, typeof(Error))]
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

        /// <summary>Removes and returns the object at the top of the Stack.</summary>
        /// <returns>The object removed from the top of the Stack.</returns>
        [HttpGet("[action]")]
        [SwaggerResponse(200, typeof(Item))]
        [SwaggerResponse(400, typeof(Error))]
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

        /// <summary>Inserts an object at the top of the Stack.</summary>
        /// <param name="item">The object to push onto the Stack.</param>
        [HttpPost("[action]")]
        [SwaggerResponse(200, typeof(void))]
        public void Push([FromBody] Item item)
        {
            Stack.Push(item);
        }

        /// <summary>Copies the Stack to a new array.</summary>
        /// <returns>A new array containing copies of the elements of the Stack.</returns>
        [HttpGet("[action]")]
        [SwaggerResponse(200, typeof(Item[]))]
        public Item[] ToArray()
        {
            return Stack.ToArray();
        }
    }
}