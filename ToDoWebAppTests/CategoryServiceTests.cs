using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToDoWebApp.Data;
using ToDoWebApp.Models;
using ToDoWebApp.Services;
using Xunit;

namespace ToDoWebAppTests
{
    public class CategoryServiceTests
    {
        private Mock<ToDoContext> contextMock;
        private ICategoryService service;

        public CategoryServiceTests()
        {
            //SetUp
      
           var categories = new List<Category>
            {
                new Category{CategoryId = 1 ,Name = "KategorijaForTest"}
            }.AsQueryable();

            var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.AsQueryable().Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.AsQueryable().Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.AsQueryable().ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            contextMock = new Mock<ToDoContext>();
          
            contextMock.Setup(m => m.Categories).Returns(mockSet.Object);
            
            service = new CategoryService(contextMock.Object);

        }

        [Fact]
        public void AddCategory_passValidData_Ok()
        {
            //Act
            service.AddCategory(new Category
            {
                Name = "KategorijaForTest"
            });

            // Assert 
            var mark = contextMock.Object.Categories.FirstOrDefault(m => m.Name == "KategorijaForTest");

            //Assert
            Assert.NotNull(mark);
        }
    }
}
