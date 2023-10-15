using Xunit;
using Moq;
using TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;
using FluentValidation;
using FluentValidation.Results;

public class ClientOperationsServiceTests
{
    private readonly Mock<IClientOperationsRepository> _repository= new();
    private readonly Mock<IValidationPrimitivesService> _validationPrimitives = new();
    private readonly Mock<IValidator<Client>> _validator = new();

    #region AddClientAsync

    [Fact]
    public async Task AddClientAsync_NormalData_ShouldCallRepository()
    {
        // Arrange
        var client = new Client
        {
            Inn = 1111122233,
            Name = "Борислав Алексей Юрьевич",
            Type = ClientType.IndividualEntrepreneurs
        };

        _validator.Setup(v => v.Validate(client)).Returns(new ValidationResult());
        _repository.Setup(r => r.AddClientAsyncDb(client)).Verifiable();

        var service = new ClientOperationsService(_repository.Object, _validator.Object, _validationPrimitives.Object);

        // Act
        await service.AddClientAsync(client);

        // Assert
        _repository.Verify(r => r.AddClientAsyncDb(client), Times.Once);
    }

    #endregion

    #region GetClientByInn

    [Theory]
    [InlineData(1000000000)]
    [InlineData(9999999999)]
    public async Task GetClientByInn_NormalData_ShouldReturnClient(long inn)
    {
        // Arrange
        var expectedClient = new Client() { 
            Inn = inn
        };

        _validationPrimitives.Setup(v => v.BeValidInn(inn));
        _repository.Setup(r => r.GetClientByInnDb(inn)).ReturnsAsync(expectedClient);

        var service = new ClientOperationsService(_repository.Object, _validator.Object, _validationPrimitives.Object);

        // Act
        var act = await service.GetClientByInn(inn);

        // Assert
        _validationPrimitives.Verify(v => v.BeValidInn(inn), Times.Once);
        _repository.Verify(r => r.GetClientByInnDb(inn), Times.Once);
    }

    #endregion

    #region GetClientsListByType

    [Theory]
    [InlineData(ClientType.IndividualEntrepreneurs)]
    [InlineData(ClientType.LegalEntities)]
    public async Task GetClientsListByType_NormalData_ShouldReturnClientList(ClientType type)
    {
        // Arrange
        var expectedClients = new List<Client>()
        {
            new Client()
            {
                Type = type
            }
        };

        _validationPrimitives.Setup(v => v.BeValidClientType(type));
        _repository.Setup(r => r.GetAllClientsByTypeDb(type)).ReturnsAsync(expectedClients);

        var service = new ClientOperationsService(_repository.Object, _validator.Object, _validationPrimitives.Object);

        // Act
        var result = await service.GetClientsListByType(type);

        // Assert
        Assert.Equal(expectedClients, result);
        _validationPrimitives.Verify(v => v.BeValidClientType(type), Times.Once);
        _repository.Verify(r => r.GetAllClientsByTypeDb(type), Times.Once);
    }

    #endregion
}
