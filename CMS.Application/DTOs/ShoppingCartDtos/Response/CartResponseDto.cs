﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.ShoppingCartDtos.Response
{
    public class CartResponseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }
        public string ArabicFullName {  get; set; }
        public string EnglishFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
