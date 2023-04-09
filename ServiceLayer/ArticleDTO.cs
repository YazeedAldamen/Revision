using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ArticleDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "LONGTEXT")]
        public string ArticleBody { get; set; }
        [Column(TypeName = "datetime(6)")]
        public DateTime LastUpdate { get; set; }
        [Column(TypeName = "datetime(6)")]
        public DateTime PublishDate { get; set; }
        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string Identifier { get; set; }
        [Column(TypeName = "LONGTEXT")]
        public string ShortDescription { get; set; }
        [Column(TypeName = "LONGTEXT")]
        public string ReadingTime { get; set; }
        [Column(TypeName = "LONGTEXT")]
        public string MetaDescription { get; set; }
        [Column(TypeName = "TINYINT")]
        public int IsBlocked { get; set; }
        public int CategoryId { get; set; }
    }
}
