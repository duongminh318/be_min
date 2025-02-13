using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore.Entities
{
    public class EntityBase
    {
        // EF core mặc định, key Id thì nó hiểu đây là khoá chính
        public Guid Id { get; set; }
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /*kiểu dữ liệu khoá chính
         * Dự án nhỏ: Int (DatabaseGeneratedOption.Identity), Guid
         * Dự án lớn (Phân tán) : Snowflake-alike ID
         */
        public DateTime CreatedDate { get; set; }
        //public EntityStatus Status { get; set; }
    }
}
