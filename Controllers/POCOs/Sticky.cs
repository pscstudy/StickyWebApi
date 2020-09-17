using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyWebApi.Controllers.POCOs
{
    public class Sticky
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
