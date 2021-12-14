using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateWebForm.Model
{
    public class CreateWebFormTable
    {
        /// <summary>
        /// Id (primary key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Date time
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
