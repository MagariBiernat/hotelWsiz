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

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public bool isToWorker { get; set; }

        public DateTime DateTime { get; set; }

        public bool isAnswer { get; set; }

        public bool isAnswered { get; set; }
    
        public int isAnswerTo { get; set; }

    }
}
