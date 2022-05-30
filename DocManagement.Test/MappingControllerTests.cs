using Autofac.Extras.Moq;
using DocManagement.API.Controllers;
using DocManagement.Service.Interfaces;
using DocManagement.Service.Models;
using DocManagement.Service.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Test
{
    public class MappingControllerTests
    {


        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            //Arrang
            var mappingServiceMock = new Mock<IMappingService>();
            mappingServiceMock
                .Setup(service => service.GetAll())
                .ReturnsAsync(new List<Mapping>() { new()
                {
                    DocumentID=1,KeywordID=1
                } });




            var apiController = new MappingController(mappingServiceMock.Object);

            //Act
            var result =(OkObjectResult)await apiController.Select_Mappings();

            //Assert
            result.StatusCode.Should().Be(200);        }






        [Fact]
        public async Task Get_OnSuccess_InvokeMappingServiceExactlyOnce()
        {
            //Arrang
            var mappingServiceMock = new Mock<IMappingService>();
            mappingServiceMock
                .Setup(service=>service.GetAll())
                .ReturnsAsync(new List<Mapping>());


            var apiController = new MappingController(mappingServiceMock.Object);


            //Act
            var result = await apiController.Select_Mappings();

            //Assert
            mappingServiceMock.Verify(service => service.GetAll(), Times.Once);
        }



        [Fact]
        public async Task Get_OnSuccess_ReturnListOfMappings()
        {
            //Arrang
            var mappingServiceMock = new Mock<IMappingService>();
            mappingServiceMock
                .Setup(service => service.GetAll())
                .ReturnsAsync(new List<Mapping>() { new()
                {
                    DocumentID=1,KeywordID=1
                } });


            var apiController = new MappingController(mappingServiceMock.Object);


            //Act
            var result = await apiController.Select_Mappings();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Mapping>>();
 
        }




        [Fact]
        public async Task Get_OnNoMappingsFound_Return404()
        {
            //Arrang
            var mappingServiceMock = new Mock<IMappingService>();
            mappingServiceMock
                .Setup(service => service.GetAll())
                .ReturnsAsync(new List<Mapping>());


            var apiController = new MappingController(mappingServiceMock.Object);


            //Act
            var result = await apiController.Select_Mappings();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            

        }


        #region Add New Mapping  

        [Fact]
        public async void Add_OnSuccess_Return_OkResult()
        {
 

            //Arrang
            var mappingServiceMock = new Mock<IMappingService>();
            mappingServiceMock
                      .Setup(service => service.GetAll())
                      .ReturnsAsync(new List<Mapping>() { new()
                {
                    DocumentID=1,KeywordID=1
                } });

            var controller = new MappingController(mappingServiceMock.Object);
            var mapping = new Mapping() { DocumentID=1,KeywordID=1 };

            //Act  
            var data = await controller.Insert_Mapping(mapping);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }



        [Fact]
        public async Task Add_ShouldCall_IMappingService_Add_AtleastOnce()
        {
            /// Arrange
            var mappingService = new Mock<IMappingService>();
            var newMapping = MappingMockData.newMapping();
            var sut = new MappingController(mappingService.Object);

            /// Act
            var result = await sut.Insert_Mapping(newMapping);

            /// Assert
            mappingService.Verify(_ => _.Add(newMapping), Times.Exactly(1));
        }



        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange
            var mappingService = new Mock<IMappingService>();
            var controller = new MappingController(mappingService.Object);
            var mappingID = 1;

            //Act
            var data = await controller.Delete_Mapping(mappingID);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

      

        //[Fact]
        //public async void Add_InvalidData_Return_BadRequest()
        //{

        //    //Arrang
        //    var mappingServiceMock = new Mock<IMappingService>();
        //    mappingServiceMock
        //              .Setup(service => service.GetAll())
        //              .ReturnsAsync(new List<Mapping>() { new()
        //        {
        //            DocumentID=1,KeywordID=1
        //        } });

        //    var controller = new MappingController(mappingServiceMock.Object);
        //    var mapping = new Mapping() { DocumentID = -1, KeywordID = -0 };

        //    //Act  
        //    var data = await controller.Insert_Mapping(mapping);

        //    //Assert  

        //    Assert.IsType<BadRequestResult>(data);
        //}



        #endregion

        //[Fact]
        //public void GetAll_NoCondition_ReturnMappings()
        //{

        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<IMappingService>()
        //            .Setup(x => x.GetAll())
        //            .Returns()


        //    }
        //    //var mappingServiceMock = new Mock<IMappingService>();
        //    //var apiController = new MappingController(mappingServiceMock.Object);
        //    //apiController.Select_Mappings();
        //    //mappingServiceMock.Verify(x => x.GetAll());

        //}

    }
}
