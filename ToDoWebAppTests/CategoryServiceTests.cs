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

        /* Connect TodoService with InMemoryProvider. ( I Used CategoryService for mySelf ... ) */

        /* And Here is my all 5 extra:

                 What extra features you can add and test:::::: */

        public CategoryServiceTests()
        {
            //SetUp
      
           var categories = new List<Category>
            {
                new Category{CategoryId = 1 ,Name = "KategorijaForTest"},
                new Category{CategoryId = 2 ,Name = "Kategorija1"}
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

            var mark = contextMock.Object.Categories.FirstOrDefault(m => m.Name == "KategorijaForTest");

            //Assert
            Assert.NotNull(mark);
        }

        [Fact]
        public void FindCategory_passValidData_Ok()
        {
            // Arange ()
            Category goodAct;

            //Act
            goodAct = service.Find("Kategorija1");
            var mark = contextMock.Object.Categories.FirstOrDefault(m => m.Name == "Kategorija1");

            //Assert
            Assert.NotNull(mark);
            Assert.Null(goodAct);
        }

        [Fact]
        public void GetAll_passValidData_Ok()
        {
            // Arange ()
            IEnumerable<Category> goodCategories;

            //Act
            goodCategories = service.GetAll();

            //Assert
            Assert.NotNull(goodCategories);
        }

        /********************************/
        /*Against(PassUnValidData) TEST*/
        /******************************/
        [Fact]
        public void AddCategory_PassUnValidData_Ok()
        {
            //Act
            var mark = contextMock.Object.Categories.FirstOrDefault(m => m.Name == "KategorijaForTestKategorijaForTestKategorijaForTestKategorijaForTestKategorijaForTest");

            //Assert
            Assert.Null(mark);
            Assert.Throws<ArgumentException>(() => service.AddCategory(new Category
            {
                Name = "KategorijaForTestKategorijaForTestKategorijaForTestKategorijaForTestKategorijaForTest"
            }));
        }

        [Fact]
        public void FindCategory_PassUnValidData_Ok()
        {
            //Act
            var mark = contextMock.Object.Categories.FirstOrDefault(m => m.Name == "Kategorija1");

            //Assert
            Assert.NotNull(mark);
            Assert.Throws<ArgumentException>(() => service.Find("Kategorija2323232"));
        }
    }
}
