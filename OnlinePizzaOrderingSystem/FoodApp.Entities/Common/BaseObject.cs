using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Entities.Common
{
    public abstract class BaseObject
    {
        /// <summary>
        /// Key for all entities
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Date in UTC when a item is created
        /// </summary>
        /// 
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date in UTC when the item was last modified
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// Date in UTC when the item was deleted
        /// </summary>
        public DateTime? DeletedDate { get; set; }
    }
}
