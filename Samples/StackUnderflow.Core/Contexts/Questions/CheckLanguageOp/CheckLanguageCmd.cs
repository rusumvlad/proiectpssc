﻿using System.ComponentModel.DataAnnotations;


namespace StackUnderflow.Domain.Schmea.Questions.CheckLanguageOp
{
    public class CheckLanguageCmd
    {
        public CheckLanguageCmd(string text)
        {
            Text = text;
        }

        [Required]
        public string Text { get; }
    }
}
