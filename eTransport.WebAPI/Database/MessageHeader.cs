using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public class MessageHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageHeaderID { get; set; }
        public User From { get; set; }
        public int FromID { get; set; }
        public User To { get; set; }
        public int ToID { get; set; }
        public DateTime Sent { get; set; }

    }
}
