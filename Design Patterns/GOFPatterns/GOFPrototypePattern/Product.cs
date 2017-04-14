using System;

namespace PrototypePattern
{
    public abstract class CloneableProduct : ICloneable
    {
        private ProductType _productTypeEnum = ProductType.NONE;

        public ProductType Type { get => _productTypeEnum; set => _productTypeEnum = value; }

        //POI: Implemented interface method can have 'public' modifier if not implemented explicitly
        //POI: Implemented interface method can be abstract
        public abstract object Clone();

        public TModel Clone<TModel>() where TModel : class
        {
            //POI: 'this' will always refer to the proper object. i.e. will refer to the object 
            //instance that will implement this Type
            return this.Clone() as TModel;
        }
    }
}
