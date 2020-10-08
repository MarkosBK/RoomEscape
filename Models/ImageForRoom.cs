using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_ComplexEx.Models
{
    public class ImageForRoom: IEntity
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool IsLogo { get; set; }
    }
}