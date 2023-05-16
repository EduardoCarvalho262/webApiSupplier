using FluentAssertions;
using Supplier.Infra.Repository;

namespace Supplier.UnitTests.Infra
{
    public class InfraTests
    {
        [Fact]
        public void GivenACallToRepository_WhenGettingAllSuplliers_ThenReturnAListOfSuppliers()
        {
            //Arrage
            var supplierRepository = new SupplierRepository();

            //Act
            var response = supplierRepository.GetAllSuppliers();

            //Assert
            response.Should().NotBeEmpty();
        }
    }
}
