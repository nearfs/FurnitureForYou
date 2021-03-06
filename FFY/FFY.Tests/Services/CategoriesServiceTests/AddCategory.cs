﻿using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.CategoriesServiceTests
{
    [TestFixture]
    public class AddCategory
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullCategoryIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object, 
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullCategoryIsPassed()
        {
            // Arrange
            var expectedExMessage = "Category cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => categoriesService.AddCategory(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallAddMethodOfCategoryRepositoryOnce_WhenACategoryIsPassed()
        {
            // Arrange
            var category = new Mock<Category>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            mockedCategoryRepository.Setup(cr => cr.Add(It.IsAny<Category>())).Verifiable();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act
            categoriesService.AddCategory(category.Object);

            // Assert
            mockedCategoryRepository.Verify(cs => cs.Add(category.Object), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWorkOnce_WhenACategoryIsPassed()
        {
            // Arrange
            var category = new Mock<Category>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoryRepository = new Mock<IGenericRepository<Category>>();
            var mockedProductRepository = new Mock<IGenericRepository<Product>>();

            var categoriesService = new CategoriesService(mockedUnitOfWork.Object,
                mockedCategoryRepository.Object,
                mockedProductRepository.Object);

            // Act
            categoriesService.AddCategory(category.Object);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
