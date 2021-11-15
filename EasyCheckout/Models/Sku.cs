using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCheckout.Models
{
    public class Sku
    {
        [BsonId]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
        public virtual List<SubProperty> SubProperties { get; set; }
        public bool HasSubProperties { get; set; }

        internal bool HasSubProperty(List<SubProperty> list)
        {
            if (list != null)
            {
                return HasSubProperties = true;
            }
            return HasSubProperties = false;
        }

        internal List<SubProperty> IdentifyProperties(List<SubProperty> list)
        {
            if (list.Count > 0)
            {
                foreach (var i in list)
                {
                    i.Id = Guid.NewGuid();
                }
                return list;
            }
            return new List<SubProperty>();
        }
    }

    public class SubProperty
    {
        [BsonId]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
