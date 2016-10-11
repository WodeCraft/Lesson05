using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lesson05.Models
{
    public class ParkingTicketMachine
    {
        private int minutesPrKr = 3;
        private int[] coinsToInsert = { 1, 2, 5, 10, 20 };
        private int amountInserted;
        private DateTime timeNow;

        [Display(Name = "Time now")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime TimeNow
        {
            get
            {
                return timeNow;
            }
        }

        [DisplayName("Paid until")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime PaidUntil
        {
            get
            {
                // Each minute is valid for 3 minutes (2 kr = 6 minutes)
                return timeNow.AddMinutes(amountInserted * minutesPrKr);
            }
        }

        [DisplayName("Display info")]
        public string Info { get; set; }

        public int AmountInserted
        {
            get
            {
                return amountInserted;
            }
        }

        public ParkingTicketMachine()
        {
            amountInserted = 0;
            timeNow = DateTime.Now;
        }

        public void InsertCoin(int kr)
        {
            amountInserted += kr;
        }

    }
}