using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StickyWebApi.Controllers.POCOs;

namespace StickyWebApi.Controllers
{
    [ApiController]
    [Route("Sticky")]
    public class StickyController : ControllerBase
    {
        public static ConcurrentDictionary<Guid, Sticky> Stickies { get; } = new ConcurrentDictionary<Guid, Sticky>();

        public static int StikeyNumber { get; set; } = 0;

        [HttpGet()]
        public IEnumerable<Sticky> GetList()
        {
            return Stickies.Values;
        }

        [HttpGet("{id}")]
        public Sticky Get(Guid id)
        {
            return Stickies[id];
        }

        [HttpGet("add")]
        public Sticky AddSticky(string title, string text)
        {
            StikeyNumber++;
            var newSticky = new Sticky()
            {
                Id = Guid.NewGuid(),
                Title = $"#{StikeyNumber} {title}",
                Text = text,
            };
            Stickies.AddOrUpdate(newSticky.Id, (id) => newSticky, (id, sticky) => sticky);
            return newSticky;
        }
    }
}
