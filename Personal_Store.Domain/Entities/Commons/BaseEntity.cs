using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Store.Domain.Entities.Commons
{
    public class BaseEntity<TKey>
    {
        public TKey ID { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<long> { }
}
