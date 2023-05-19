﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Supplier.Domain.Models;
using Supplier.Infra.Interfaces;
using Supplier.Infra.Repository;
using System.Linq;

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
        public void GivenARequestToRepository_WhenGetASupplierId_ThenReturnALSupplier()
        {
            // Arrange
            var supplierContextMock = new Mock<ISupplierContext>();
            var supplier = new SupplierType { Id = 1, FantasyName = "Supplier 1" };
            var supplierDbSetMock = CreateMockDbSet(new List<SupplierType> { supplier } );

            supplierContextMock.Setup(c => c.Supplier.Single(It.IsAny<Func<SupplierType>>())).Returns(supplierDbSetMock.Object);

            var supplierRepository = new SupplierRepository(supplierContextMock.Object);

            // Act
            var result = supplierRepository.GetSupplier(1);

            // Assert
            result.Should().NotBeNull();
            result.Result.Id.Should().Be(supplier.Id);
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