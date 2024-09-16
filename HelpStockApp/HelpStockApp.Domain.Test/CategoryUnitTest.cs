using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Test
{
    #region Testes Positivos de Categoria
    public class CategoryUnitTest
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParemeters_ResultObjectsValidState()
        {
            Action action= () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = " Create Category With Parameter Name Alone ")]
        public void CreateCategory_WithParameterNameAlone_ResultException()
        {
            Action action = () => new Category("Alone");
            action.Should().Throw<DomainExceptionValidation>().WithMessage(""); ;
        }
        #endregion

    #region Teste Negativos de Categoria
        [Fact(DisplayName ="Create Category With Invalid Id")]
    public void CreateCategory_WithInvalidParemetersId_ResultException()
    {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");

    }



        [Fact(DisplayName = " Create Category With Name Too Short Parameter ")]
        public void CreateCategory_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Category(3, "AB");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name,  too short, Minimum 3 characters");
        }
        [Fact(DisplayName = " Create Category With Name Null Parameter ")]
        public void CreateCategory_WithNameNullParameter_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }
        [Fact(DisplayName = " Create Category With Name Missing Parameter ")]
        public void CreateCategory_WithNameMissingParameter_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required"); ;
        }

        /*Nao é um teste humano*/
        //[Fact(DisplayName = " Create Category With Invalid Id Caracter Id ")]
        //public void CreateCategory_WithInvalidIdCaracterId_ResultException()
        //{
        //    Action action = () => new Category("Category");
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id, Int Type Required"); ;
        //}


        

    }
        #endregion

}
/*
Create Category With Name Too Short Parameter
Create Category With Name Null Parameter
Create Category With Name Missing Parameter
Create Category With Invalid Id Caracter Id
Create Category With Parameter Name Alone
 */