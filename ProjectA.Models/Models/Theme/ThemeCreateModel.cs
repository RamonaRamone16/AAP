using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectA.Models.Models.Theme
{
    public class ThemeCreateModel
    {
        [Required(ErrorMessage = "Введите заголовок темы")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите содержание темы")]
        [StringLength(2500, MinimumLength = 20, ErrorMessage = "Мин. количество символов - 20")]
        public string Content { get; set; }
    }
}
