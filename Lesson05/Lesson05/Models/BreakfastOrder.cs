using System;
using System.ComponentModel.DataAnnotations;

namespace Lesson05.Models
{
    public class BreakfastOrder
    {

        public string Fullname { get; set; }
        public int Roomnumber { get; set; }

        public string Breakfast { get; set; }

        public decimal TotalOrderPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
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