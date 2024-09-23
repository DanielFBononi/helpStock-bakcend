using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectsValidState()
        {
            Action action = () => new Product(1,"Product Name","description",10, 1, "Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName= "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParametersId_ResultException()
        {
            Action action = () => new Product(-1, "Product Name", "Desciption", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName ="Create Product With Name Invalid")]
        public void CreateProduct_WithNameInvalidParameters_ResultException()
        {
            Action action = () => new Product(1, "El", "Description", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName ="Create Product With Image Too Long")]
        public void CreateProduct_WithImageTooLongParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 10, 1, "https://www.google.com/search?q=url+com++de+251+caracteres&sca_esv=60dc7b8df89f0db7&sca_upv=1&rlz=1C1GCEU_pt-BRBR1123BR1123&ei=dXPxZta5IvDc5OUP2Jem6Aw&ved=0ahUKEwiWyJKAnNmIAxVwLrkGHdiLCc0Q4dUDCA8&uact=5&oq=url+com++de+251+caracteres&gs_lp=Egxnd3Mtd2l6LXNlcnAiGnVybCBjb20gIGRlIDI1MSBjYXJhY3RlcmVzMggQIRigARjDBEi9D1CuA1jFDXADeAGQAQCYAbIBoAG_BqoBAzAuNrgBA8gBAPgBAZgCCKACoAXCAgoQABiwAxjWBBhHwgIIEAAYgAQYogTCAgQQIRgKmAMAiAYBkAYIkgcDMy41oAesDw&sclient=gws-wiz-serp");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }
        [Fact(DisplayName ="Create Product With Image Null")]
        public void CreateProduct_WithImageNullParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 10, 1, null);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Image Empty")]
        public void CreateProduct_WithImageEmptyParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 10, 1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image URL, URL not a found or no exist");
        }
        [Fact(DisplayName = "Create Product With Stock Negative")]
        public void CreateProduct_WithStockNegativeParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 10, -1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Price Negative")]
        public void CreateProduct_WithPriceNegativeParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Description", -10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price, Price negative value is unlikely!");
        }

        /*4 Adicionais*/

        [Fact(DisplayName = "Create Product With Invalid Description ")]
        public void CreateProduct_WithInvalidDescriptionParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, too short. minimum 5 characters!");
        }
        [Fact(DisplayName = "Create Product With Empty Name ")]
        public void CreateProduct_WithEmptyNameParameters_ResultException()
        {
            Action action = () => new Product(1, "", "Description", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }
        [Fact(DisplayName = "Create Product With Description Too Long ")]
        public void CreateProduct_WithDescriptionTooLongParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "é um gerador on-line falso texto livre. Ele oferece um simulador de texto completo para gerar texto de substituição ou texto alternativo para seus modelos", 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, Too Long, Maximum 50 characters");
        }
        [Fact(DisplayName = "Create Product With Empty Description ")]
        public void CreateProduct_WithEmptyDescriptionParameters_ResultException()
        {
            Action action = () => new Product(1, "Product Name", "" , 10, 1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }







    }
}
