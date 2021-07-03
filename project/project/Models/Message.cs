using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string MessageContent { get; set; }

        [Required]
        public int FromEmail { get; set; }

        public int ToEmail { get; set; }

        [Required]
        public bool isToWorker { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool isAnswer { get; set; }
    
        public int isAnswerTo { get; set; }

    }
}
