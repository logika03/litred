using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Entities
{
    public class SubscriptionType : EntityDescription, IComparable
    {
        public int MonthPrice { get; set; }
        public int MonthCount { get; set; }

        public IEnumerable<SubscriptionOption> SubscriptionOptions { get; set; }

        // public IEnumerable<User> Users { get; set; }
        public IEnumerable<Book> Books { get; set; }

        // [NotMapped] public static string Free { get; set; } = "Free";
        // [NotMapped] public static string Standard { get; set; } = "Standard";
        // [NotMapped] public static string Premium { get; set; } = "Premium";
        public int CompareTo(object obj)
        {
            if (obj is null)
                return -1;
            var objDescription = (obj as SubscriptionType)?.Description;
            if (Description == objDescription)
                return 0;
            if (objDescription == SubscriptionTypeEnums.Free)
                return 1;
            if (objDescription == SubscriptionTypeEnums.Premium)
                return -1;
            if (objDescription == SubscriptionTypeEnums.Standard && Description == SubscriptionTypeEnums.Free)
                return -1;
            return 1;
        }
    }
}
