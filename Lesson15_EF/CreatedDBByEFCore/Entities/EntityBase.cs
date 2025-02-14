using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore.Entities
{
    public class EntityBase
    {
        // EF core mặc định, Key Id thì nó hiểu đây là khoá chính
        public Guid Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        /* kiểu dữ liệu Khoá chính
         *   Dự án nhỏ: Int (DatabaseGeneratedOption.Identity), Guid
             Dự án lớn (phân tán): Snowflake-alike ID
         */

        public DateTime Created { get; set; } = DateTime.Now;  // ngày tạo
        public DateTime Updated { get; set; } = DateTime.Now;  // Ngày chỉnh sửa
        [MaxLength(50)]
        public string? UserNameCreated { get; set; }   // người tạo
        [MaxLength(50)]
        public string? UserNameUpdated { get; set; }  // người sửa
        [MaxLength(256)]
        public string? Filter { get; set; }      // cho phép lọc thông tin ở nhiều trường
        [MaxLength(256)]
        public string? ExtraField1 { get; set; }   // Trường mở rộng, tạo sẵn dự trù cho việc logic nghiệp mở rộng thì sử dụng, không cần phải tạo thêm cột
        [MaxLength(256)]
        public string? ExtraField2 { get; set; }
        [MaxLength(500)]
        public string? ExtraField3 { get; set; }
    }
}
