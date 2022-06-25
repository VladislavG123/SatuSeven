using System;
using System.Linq;
using SatuSeven.Contracts.Abstract.Providers.EntityFramework.Tests.Infrastructure;
using Xunit;

namespace SatuSeven.Contracts.Abstract.Providers.EntityFramework.Tests;

public class EntityFrameworkProviderUnitTests
{
    [Fact]
    public void ProviderCreation_NoExceptionsAndProviderIsNotNullExpected()
    {
        // Arrange
        var context = new TestApplicationContext();

        // Act
        var provider = new CertainEntityFrameworkProvider(context);

        // Assert
        Assert.True(provider is not null);
    }

    [Fact]
    public async void CreateAndFindById_NotNullExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);

        // Act
        var entity = new CertainEntity();
        await provider.Add(entity);

        var entityFromDatabase = await provider.GetById(entity.Id);

        // Assert
        Assert.NotNull(entityFromDatabase);
    }

    [Fact]
    public async void CreateAndFindByIncorrectId_NullExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);

        // Act
        var entity = new CertainEntity();
        await provider.Add(entity);

        var entityFromDatabase = await provider.GetById(Guid.Empty);

        // Assert
        Assert.Null(entityFromDatabase);
    }

    [Fact]
    public async void MultipleCreationAndGetAll_CorrectNumberOfEntitiesInDatabaseExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider.GetAll();

        // Assert
        Assert.Equal(data.Count, entities.Length);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async void MultipleCreationAndGetAll_SkipOne_TakeOne_CorrectEntityInDatabaseExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider.GetAll(1, 1);

        // Assert
        Assert.Equal(data.First().Id, entities[1].Id);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async void MultipleCreationAndGetByExpression_CorrectEntityInDatabaseExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider.Get(x => x.Id.Equals(entities.First().Id));

        // Assert
        Assert.Equal(data.First().Id, entities.First().Id);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async void MultipleCreationAndGetByExpression_SkipOne_TakeOne_CorrectEntityInDatabaseExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider
            .Get(x => x.Id.Equals(entities.First().Id), 1, 1);

        // Assert
        Assert.Equal(data.First().Id, entities[1].Id);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async void MultipleCreationAndFirstOrDefault_CorrectEntityInDatabaseExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider.FirstOrDefault(x => true);

        // Assert
        Assert.NotNull(data);
        Assert.Equal(data!.Id, entities.First().Id);
    }
    
    [Fact]
    public async void MultipleCreationAndFirstOrDefault_DefaultExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};

        // Act
        await provider.AddRange(entities);
        var data = await provider.FirstOrDefault(x => x.Id.Equals(Guid.Empty));

        // Assert
        Assert.Equal(default, data);
    }

    [Fact]
    public async void CreateGetByIdAndEdit_DataChangedExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};
        
        // Act
        await provider.AddRange(entities);
        var entity = await provider.GetById(entities.First().Id);

        entity!.CreationDate = DateTime.MinValue;
        await provider.Edit(entity);

        entity = await provider.GetById(entity.Id);
        
        // Assert
        Assert.NotNull(entity);
        Assert.Equal(DateTime.MinValue, entity!.CreationDate);
    }
    
    [Fact]
    public async void DeleteAndFindById_NullExpected()
    {
        // Arrange
        var context = new TestApplicationContext();
        var provider = new CertainEntityFrameworkProvider(context);
        var entities = new CertainEntity[] {new(), new(), new(), new()};
        
        // Act
        await provider.AddRange(entities);
        var entity = await provider.GetById(entities.First().Id);

        await provider.Remove(entity!);
        
        entity = await provider.GetById(entity!.Id);
        
        // Assert
        Assert.Null(entity);
    }
}