using System;
using System.Collections.Generic;

namespace Lesson05.Models
{
    public class BreakfastOrder
    {

        public string Fullname { get; set; }
        public int Roomnumber { get; set; }

        public List<Breakfast> Breakfast { get; set; }

        public DateTime DeliveryDate { get; set; }

        public BreakfastOrder()
        {

        }

    }

    public enum Breakfast
    {
        Cornflakes,
        Egg,
        Toast,
        Juice,
        Milk,
        Coffee,
        Tea
    }
}