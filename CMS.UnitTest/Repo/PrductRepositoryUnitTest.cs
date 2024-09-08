using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.UnitTest.Shared;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitTest.Repo
{
    public class PrductRepositoryUnitTest : MockedEntities
    {
        private readonly Mock<IUnitofTestRepo> _mockrepo;
        public PrductRepositoryUnitTest()
        {
            // Make an instance of the repo mock to reach evry test method
            _mockrepo = new Mock<IUnitofTestRepo>();
        }

        [Fact]
        public async Task CreateAsync_Product_TestMethod()
        {
            //Arrange
            _mockrepo.Setup(repo => repo.productRepository.CreateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>())).ReturnsAsync(await Task.FromResult<Product>(product));

            //Acting
            IUnitofTestRepo unitofTest = _mockrepo.Object;
            var actualed_value = unitofTest.productRepository.CreateAsync(product, It.IsAny<CancellationToken>());

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task GetAllAsync_Product_TestMethod()
        {
            //Arrange
            _mockrepo.Setup(repo => repo.productRepository.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(await Task.FromResult<IEnumerable<Product>>(productList));

            //Acting
            IUnitofTestRepo unitofTest = _mockrepo.Object;
            var actualed_value = await unitofTest.productRepository.GetAllAsync(It.IsAny<CancellationToken>());

            //Asserting
            var productlists = Assert.IsAssignableFrom<IEnumerable<Product>>(actualed_value);
            //fetching the data from the product as a list
            var models = productlists.ToList();
            Assert.Equal(2, models.Count);
            Assert.NotNull(actualed_value);

        }

        [Fact]
        public async Task GetById_Product_TestMethod()
        {

            //Arrange
            _mockrepo.Setup(repo => repo.productRepository.GetByIdAsync(It.IsAny<int>(),It.IsAny<CancellationToken>())).ReturnsAsync(await Task.FromResult<Product>(product));

            //Acting
            IUnitofTestRepo unitofTest = _mockrepo.Object;
            var actualed_value = await unitofTest.productRepository.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>());

            //Asserting
            Assert.NotNull(actualed_value);
        }


        [Fact]
        public async Task UpdateAsync_Product_TestMethod()
        {
            //Arrange
            _mockrepo.Setup(repo => repo.productRepository.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>())).ReturnsAsync(await Task.FromResult<Product>(product));

            //Acting
            IUnitofTestRepo unitofTest = _mockrepo.Object;
            var actualed_value = unitofTest.productRepository.UpdateAsync(product, It.IsAny<CancellationToken>());

            //Asserting
            Assert.NotNull(actualed_value);
        }


        [Fact]
        public async Task DeleteAsync_Product_TestMethod()
        {
            //Arrange
            _mockrepo.Setup(repo => repo.productRepository.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(await Task.FromResult<bool>(true));

            //Acting
            IUnitofTestRepo unitofTest = _mockrepo.Object;
            var actualed_value = unitofTest.productRepository.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>());

            //Asserting
            Assert.NotNull(actualed_value);
        }

    }
}
