using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling.Data.Dtos.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int? RoomType { get; set; }
    }
}
