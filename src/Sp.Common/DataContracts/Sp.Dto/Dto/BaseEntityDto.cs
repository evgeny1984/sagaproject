using System;

namespace Sp.Dto.Dto
{
    public class BaseEntityDto
    {
        public int ID { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.Now;

        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
