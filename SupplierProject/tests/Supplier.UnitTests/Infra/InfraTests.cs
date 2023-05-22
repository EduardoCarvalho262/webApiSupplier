﻿using FluentAssertions;
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
        public void GivenACallToRepository_WhenGettingAllSuppliers_ThenReturnAListOfSuppliers()
        {
            // Arrange
            var supplierContextMock = new Mock<ISupplierContext>();


            var supplierList = new List<SupplierType>
            {
                new SupplierType { Id = 1, FantasyName = "Supplier 1" },
                new SupplierType { Id = 2, FantasyName = "Supplier 2" },
                new SupplierType { Id = 3, FantasyName = "Supplier 3" }
            };

            var supplierDbSetMock = CreateMockDbSet(supplierList);

            supplierContextMock.Setup(c => c.Supplier).Returns(supplierDbSetMock.Object);

            var supplierRepository = new SupplierRepository(supplierContextMock.Object);

            // Act
            var result =  supplierRepository.GetAllSuppliers();

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().HaveCount(3);
            result.Result.ToList().Should().BeEquivalentTo(supplierList);
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




        private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
        {
            var queryableData = data.AsQueryable();
            var asyncEnumerableData = new TestAsyncEnumerable<T>(queryableData);
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());
            dbSetMock.As<IAsyncEnumerable<T>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(new TestAsyncEnumerator<T>(queryableData.GetEnumerator()));

            return dbSetMock;
        }
    }
}
