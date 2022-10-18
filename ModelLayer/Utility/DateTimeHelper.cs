using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLayer.Utility
{
    public class DateTimeHelper
    {
        public static List<KeyValuePair<int, string>> GetDayOfWeekList()
        {
            Dictionary<int, string> daysList = new Dictionary<int, string>();
            Array enumValueArray = Enum.GetValues(typeof(DayOfWeek));
            foreach (int enumValue in enumValueArray)
            {
                daysList.Add(enumValue + 1, Enum.GetName(typeof(DayOfWeek), enumValue));
            }

            return daysList.ToList();
        }

        public static int GetDay(DateTime date)
        {
            return ((int)date.DayOfWeek) + 1;
        }
    }
}
