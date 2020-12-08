using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.EF.Models
{
    [Table("Question")]
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
    }
}