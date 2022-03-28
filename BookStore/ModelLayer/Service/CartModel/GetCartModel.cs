﻿using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer.Service.CartModel
{
    public class GetCartModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int user_id { get; set; }
        public int Book_id { get; set; }
        public int OrderQuantity { get; set; }
        public BookTable bookTabel { get; set; }
    }
}
