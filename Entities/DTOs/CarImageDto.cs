using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageDto:IDto
    {
        public string ImagePath { get; set; }
        public int CarId { get; set; }
    }
}
