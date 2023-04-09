using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="varchar(255)")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string Identifier { get; set; }
        [Column(TypeName ="LONGTEXT")]
        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
