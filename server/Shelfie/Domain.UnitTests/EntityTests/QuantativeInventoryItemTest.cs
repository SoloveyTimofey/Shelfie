namespace Domain.UnitTests.EntityTests
{
    public class QuantativeInventoryItemTest
    {

        [TestCase(2.5, QuantitativeUnit.SingleUnits)]
        [TestCase(2.5, QuantitativeUnit.Boxes)]
        public void QuantityChangesCorrectly_WhenQuantityIsDoubleAndQuantitativeUnitIsSinglable(double initialQuantity, QuantitativeUnit newQuantitativeUnit)
        {
            //Asign
            QuantativeInventoryItem quantativeInventoryItem = new QuantativeInventoryItem(QuantitativeUnit.Liters, initialQuantity);

            //Act
            quantativeInventoryItem.QuantitativeUnit = newQuantitativeUnit;

            //Assert
            Assert.IsTrue(quantativeInventoryItem.Quantity%1==0);
        }

        [TestCase(2, QuantitativeUnit.Meters)]
        [TestCase(2.5, QuantitativeUnit.Meters)]

        [TestCase(2, QuantitativeUnit.Liters)]
        [TestCase(2.5, QuantitativeUnit.Liters)]

        [TestCase(2, QuantitativeUnit.SquareMeters)]
        [TestCase(2.5, QuantitativeUnit.SquareMeters)]

        [TestCase(2, QuantitativeUnit.Kilograms)]
        [TestCase(2.5, QuantitativeUnit.Kilograms)] 
        public void QuantityStaysTheSame_WhenQuantitativeUnitChangesToNonsinglable(double initialQuantity, QuantitativeUnit newQuantitativeUnit)
        {
            //Asign
            QuantativeInventoryItem quantativeInventoryItem = new QuantativeInventoryItem(QuantitativeUnit.Liters, initialQuantity);

            //Act
            quantativeInventoryItem.QuantitativeUnit = newQuantitativeUnit;

            //Assert
            Assert.IsTrue(quantativeInventoryItem.Quantity==initialQuantity);
        }
    }
}
