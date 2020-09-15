using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StickyWebApi.Controllers.POCOs;

namespace StickyWebApi.Controllers
{
    /// <summary>
    /// 付箋コントローラー
    /// </summary>
    /// <remarks>
    /// http://localhost:5000/Sticky
    /// </remarks>
    [ApiController]
    [Route("Sticky")]
    public class StickyController : ControllerBase
    {
        /// <summary>
        /// 付箋一覧
        /// </summary>
        public static ConcurrentDictionary<Guid, Sticky> Stickies { get; } = new ConcurrentDictionary<Guid, Sticky>();

        /// <summary>
        /// 付箋番号
        /// </summary>
        public static int StikeyNumber { get; set; } = 0;

        /// <summary>
        /// 付箋一覧を取得する
        /// </summary>
        /// <remarks>
        /// http://localhost:5000/Sticky
        /// </remarks>
        [HttpGet()]
        public IEnumerable<Sticky> GetList()
        {
            return Stickies.Values;
        }

        /// <summary>
        /// 付箋を取得する
        /// </summary>
        /// <remarks>
        /// http://localhost:5000/Sticky/df75ce29-b19c-4b85-a9d2-96e2ae219917
        /// </remarks>
        [HttpGet("{id}")]
        public Sticky Get(Guid id)
        {
            return Stickies[id];
        }

        /// <summary>
        /// 付箋を追加する
        /// </summary>
        /// <remarks>
        /// http://localhost:5000/Sticky/add?title=今日の買い物&text=にんじん
        /// </remarks>
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
