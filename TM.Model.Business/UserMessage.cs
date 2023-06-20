using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Model.Business
{
    [Table("user_message")]
    public class UserMessage
    {
        [Key]
        public int id { get; set; }
        public int sourceId { get; set; }
        public int targetId { get; set; }
        public string message { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
