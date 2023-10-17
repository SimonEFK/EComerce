namespace HardwareStore.App.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ProductSpecificationValues
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int SpecificationValueId { get; set; }

        public SpecificationValue SpecificationValue { get; set; }

    }

}
