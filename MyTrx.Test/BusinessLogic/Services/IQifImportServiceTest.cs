using TestStack.BDDfy;
using Xunit;
using MyTrx.BusinessLogic.Services;
using Moq;
using Shouldly;

namespace MyTrx.Test
{
    [Story(
        AsA = "As a User",
        IWant = "I want to import QIF format files",
        SoThat = "So that I can have my bank transactions")]
    public class IQifImportServiceTest
    {
        private IQifImportService _qif_import_service;
        private bool result;

        void Qif_File_With_Valid_Format()
        {
            var moq = new Mock<IQifImportService>();
            moq.Setup(x => x.Import()).Returns(true);

            _qif_import_service = moq.Object;
        }

        void The_User_imports_the_file()
        {
            result = _qif_import_service.Import();
        }

        [Fact]
        public void When_Importing_a_QIF_file_that_has_data_with_valid_format()
        {
            this.Given(s => Qif_File_With_Valid_Format(), "Qif file with valid format")
                .When(s => The_User_imports_the_file(), "the User imports the file")
                .Then(s => result.ShouldBeTrue(), "result should be true")
                .BDDfy();
        }

    }
}
