using System;

namespace Models
{
    public class BirthDate
    {
        public BirthDate(int year,int month,int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public int DaysOfNextBirthDay()
        {
            var today = DateTime.Today;

            var next = new DateTime(today.Year, Month, Day);

            if(next<today)
                next = next.AddYears(1); 

            var days = (next - today).Days;

            return days;
        }
    }
}