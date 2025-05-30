﻿using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
