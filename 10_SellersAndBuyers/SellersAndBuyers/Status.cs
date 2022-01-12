using System;
using System.Collections.Generic;
using System.Text;

namespace SellersAndBuyers
{
    [Serializable]
    public enum Status
    {
        /// <summary>
        /// Статус "НОВЫЙ".
        /// </summary>
        New = 0,

        /// <summary>
        /// Статус "ОБРАБОТАН".
        /// </summary>
        Processed = 1,

        /// <summary>
        /// Статус "ОПЛАЧЕН".
        /// </summary>
        Paid = 2,

        /// <summary>
        /// Статус "ОТГРУЖЕН".
        /// </summary>
        Shipped = 3,

        /// <summary>
        /// Статус "ИСПОЛНЕН".
        /// </summary>
        Completed = 4
    }
}
