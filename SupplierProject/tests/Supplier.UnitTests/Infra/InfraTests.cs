using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Supplier.Domain.Models;
using Supplier.Infra.Context;
using Supplier.Infra.Interfaces;
using Supplier.Infra.Repository;

namespace Supplier.UnitTests.Infra
{
    public class InfraTests
    {
        [Fact]
        public async Task GivenACallToRepository_WhenGettingAllSuppliers_ThenReturnAListOfSuppliers()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var supplierList = new List<SupplierType>
            {
                new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041"  },
                new SupplierType { Id = 2, FantasyName = "Mc Donalds2", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041"  },
                new SupplierType { Id = 3, FantasyName = "Mc Donalds3", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041"  }
            };

            using (var context = new SupplierContext(options))
            {
                foreach (var item in supplierList)
                {
                    context.Add(item);
                }
                context.SaveChanges();
            }

            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.GetAllSuppliers();

                // Assert
                result.Should().NotBeNull();
                result.Should().HaveCount(3);
                result.ToList().Should().BeEquivalentTo(supplierList);
            }
        }

        [Fact]
        public async Task GivenARequestToRepository_WhenGetASupplierId_ThenReturnALSupplier()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new SupplierContext(options))
            {
                var supplier = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
                context.Supplier.Add(supplier);
                context.SaveChanges();
            }

            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.GetSupplier(1);

                // Assert
                result.Should().NotBeNull();
                result.Id.Should().Be(1);
            }
        }

        [Fact]
        public async Task GivenARequestToRepository_WhenTryToAddASupplier_ThenReturnId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var supplier = new SupplierType { FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };

            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.InsertSupplier(supplier);

                // Assert
                result.Should().NotBeNull();
                result.Id.Should().Be(1);
            }
        }

        [Fact]
        public async Task GivenARequestToRepository_WhenTryToUpdateASupplier_ThenReturnIdAndName()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new SupplierContext(options))
            {
                var supplierTest = new SupplierType { Id = 1, FantasyName = "Mac Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
                context.Supplier.Add(supplierTest);
                context.SaveChanges();
            }

            var supplier = new SupplierType { Id = 1, FantasyName = "Mc Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
            var FantasyNameExpected = "Mc Donalds";
            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.UpdateSupplier(supplier);

                // Assert
                result.Should().NotBeNull();
                result.Id.Should().Be(1);
                result.FantasyName.Should().Be(FantasyNameExpected);
            }
        }

        [Fact]
        public async Task GivenARequestToRepository_WhenTryToDeleteASupplier_ThenReturnTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new SupplierContext(options))
            {
                var supplierTest = new SupplierType { Id = 1, FantasyName = "Mac Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
                context.Supplier.Add(supplierTest);
                context.SaveChanges();
            }

            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.DeleteSupplier(1);

                // Assert
                result.Should().BeTrue();
            }
        }

        [Fact]
        public async Task GivenAEmptySupplierToRepository_WhenTryToDeleteASupplier_ThenReturnFalse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SupplierContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new SupplierContext(options))
            {
                var supplierTest = new SupplierType { Id = 2, FantasyName = "Mac Donalds", Cnpj = "00000/000-85", Email = "mac@gmail.com", Telephone = "11985092041" };
                context.Supplier.Add(supplierTest);
                context.SaveChanges();
            }

            using (var context = new SupplierContext(options))
            {
                var supplierRepository = new SupplierRepository(context);

                // Act
                var result = await supplierRepository.DeleteSupplier(1);

                // Assert
                result.Should().BeFalse();
            }
        }
    }
}
