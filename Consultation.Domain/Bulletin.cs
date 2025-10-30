using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace Consultation.Domain
{
    public class Bulletin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BulletinID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public BulletinStatus Status { get; set; }    

        public DateTime DatePublished { get; set; }

        public int FileCount { get; set; }

        public bool IsArchived { get; set; }
    }
}
