using Domain.Enums;

namespace Domain.Entities
{
    public class QuantativeInventoryItem : InventoryItem
    {
        public QuantativeInventoryItem(QuantitativeUnit quantitativeUnit, double quantity)
        {
            this.QuantitativeUnit = quantitativeUnit;
            this.Quantity = quantity;
        }
        private double _quantity;
        public double Quantity
        {
            get=>_quantity;
            set
            {
                if(QuantitativeUnit==QuantitativeUnit.Boxes||QuantitativeUnit == QuantitativeUnit.SingleUnits)
                {
                    _quantity = Math.Round(value);
                }
                else
                {
                    _quantity = value;
                }
            }
        }
        private QuantitativeUnit _quantitativeUnit;
        public QuantitativeUnit QuantitativeUnit
        {
            get=>_quantitativeUnit;
            set
            {
                if (value==QuantitativeUnit.Boxes||value==QuantitativeUnit.SingleUnits)
                {
                    Quantity = Math.Round(_quantity);
                }
                _quantitativeUnit = value;
            }
        }
    }
}
